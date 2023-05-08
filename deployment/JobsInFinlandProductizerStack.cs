using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pulumi;
using Pulumi.Aws.Iam;
using Pulumi.Aws.Lambda;
using Pulumi.Aws.Lambda.Inputs;
using Pulumi.Command.Local;

namespace ProductizerStack;

public class JobsInFinlandProductizerStack : Stack
{
    public JobsInFinlandProductizerStack()
    {
        var config = new Config();
        var environment = Deployment.Instance.StackName;
        var projectName = Deployment.Instance.ProjectName;
        var artifactPath = config.Get("artifactPath") ?? "release/";
        var tags = new InputMap<string>
        {
            {
                "vfd:stack", environment
            },
            {
                "vfd:project", projectName
            }
        };

        var role = new Role($"{projectName}-lambda-role-{environment}", new RoleArgs
        {
            AssumeRolePolicy = JsonSerializer.Serialize(
                new Dictionary<string, object?>
                {
                    { "Version", "2012-10-17" },
                    {
                        "Statement", new object[]
                        {
                            new Dictionary<string, object?>
                            {
                                { "Action", "sts:AssumeRole" },
                                { "Effect", "Allow" },
                                {
                                    "Principal", new Dictionary<string, object?>
                                    {
                                        { "Service", "lambda.amazonaws.com" }
                                    }
                                }
                            }
                        }
                    }
                }),
            Tags = tags
        });

        var rolePolicyAttachment = new RolePolicyAttachment($"{projectName}-lambda-role-attachment-{environment}",
            new RolePolicyAttachmentArgs
            {
                Role = Output.Format($"{role.Name}"),
                PolicyArn = ManagedPolicy.AWSLambdaBasicExecutionRole.ToString()
            });

        var authenticationGatewayRef =
            new StackReference($"{Deployment.Instance.OrganizationName}/authentication-gw/{environment}");

        var lambdaFunction = new Function($"{projectName}-{environment}", new FunctionArgs
        {
            Role = role.Arn,
            Runtime = "dotnet6",
            Handler = "JobsInFinland.Api.Productizer",
            Timeout = 15,
            MemorySize = 1024,
            Environment = new FunctionEnvironmentArgs
            {
                Variables = new InputMap<string>
                {
                    { "ASPNETCORE_ENVIRONMENT", environment },
                    { "AuthGwBaseAddress", authenticationGatewayRef.GetOutput("endpoint").Apply(o => o!.ToString())! }
                }
            },
            Tags = tags,
            Code = new FileArchive(artifactPath)
        });
        LambdaId = lambdaFunction.Name;

        var functionUrl = new FunctionUrl($"{projectName}-function-url-{environment}", new FunctionUrlArgs
        {
            FunctionName = lambdaFunction.Arn,
            AuthorizationType = "NONE"
        });

        var command = new Command($"{projectName}-add-permissions-command-{environment}", new CommandArgs
            {
                Create = Output.Format(
                    $"aws lambda add-permission --function-name {lambdaFunction.Arn} --action lambda:InvokeFunctionUrl --principal '*' --function-url-auth-type NONE --statement-id FunctionUrlAllowAccess")
            }, new CustomResourceOptions
            {
                DeleteBeforeReplace = true,
                DependsOn = new InputList<Resource>
                {
                    lambdaFunction
                }
            }
        );

        ApplicationUrl = functionUrl.FunctionUrlResult;
    }

    [Output] public Output<string> ApplicationUrl { get; set; }
    [Output] public Output<string> LambdaId { get; set; }
}
