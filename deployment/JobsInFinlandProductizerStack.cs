using System.Collections.Generic;
using System.Text.Json;
using Pulumi;
using Pulumi.Aws.Iam;
using Pulumi.AwsNative.IAM.Inputs;
using Pulumi.AwsNative.Lambda;
using Pulumi.AwsNative.Lambda.Inputs;
using Pulumi.Command.Local;
using AwsClassic = Pulumi.Aws;
using Role = Pulumi.AwsNative.IAM.Role;
using RoleArgs = Pulumi.AwsNative.IAM.RoleArgs;

public class JobsInFinlandProductizerStack : Stack
{
    public JobsInFinlandProductizerStack()
    {
        var config = new Config();
        var environment = Deployment.Instance.StackName;
        var projectName = Deployment.Instance.ProjectName;
        var artifactPath = config.Get("artifactPath") ?? "release/";

        var role = new Role($"{projectName}-lambda-role-{environment}", new RoleArgs
        {
            AssumeRolePolicyDocument = JsonSerializer.Serialize(
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
            Tags = new InputList<RoleTagArgs>
            {
                new RoleTagArgs { Key = "vfd:stack", Value = environment },
                new RoleTagArgs { Key = "vfd:project", Value = projectName }
            }
        });

        var rolePolicyAttachment = new RolePolicyAttachment($"{projectName}-lambda-role-attachment-{environment}",
            new RolePolicyAttachmentArgs
            {
                Role = Output.Format($"{role.RoleName}"),
                PolicyArn = ManagedPolicy.AWSLambdaBasicExecutionRole.ToString()
            });

        var lambdaFunction = new Function($"{projectName}-{environment}", new FunctionArgs
        {
            Role = role.Arn,
            Runtime = "dotnet7",
            Handler = "JobsInFinland.Api.Productizer",
            Timeout = 15,
            Environment = new FunctionEnvironmentArgs
            {
                Variables = new InputMap<string>
                {
                    { "ASPNETCORE_ENVIRONMENT", environment }
                }
            },
            Tags = new InputList<FunctionTagArgs>
            {
                new FunctionTagArgs { Key = "vfd:stack", Value = environment },
                new FunctionTagArgs { Key = "vfd:project", Value = projectName }
            },
            Code = new FunctionCodeArgs
            {
                ZipFile = new FileArchive(artifactPath).ToString() ?? artifactPath
            }
        });

        var functionUrl = new Url($"{projectName}-function-url-{environment}", new UrlArgs
        {
            TargetFunctionArn = lambdaFunction.Arn,
            AuthType = UrlAuthType.None
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

        ApplicationUrl = functionUrl.FunctionUrl;
    }

    [Output] public Output<string> ApplicationUrl { get; set; }
}
