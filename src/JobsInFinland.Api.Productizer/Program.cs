using FluentValidation;
using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Client;
using JobsInFinland.Api.Productizer.Middleware;
using JobsInFinland.Api.Productizer.Models.Testbed;
using JobsInFinland.Api.Productizer.Services;
using JobsInFinland.Api.Productizer.Services.Codeset;
using JobsInFinland.Api.Productizer.Services.Validation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
builder.Services.AddSingleton<IJobsInFinlandApiClient, JobsInFinlandApiClient>();

builder.Services.AddSingleton<IMunicipalityCodesetService, MunicipalityCodesetService>();
builder.Services.AddSingleton<IOccupationCodesetService, OccupationCodesetService>();
builder.Services.AddSingleton<ICodeMapperFactory, CodeMapperFactory>();

builder.Services.AddScoped<IValidator<JobsPostingRequest>, JobPostingRequestValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IAuthorizationService, AuthorizationService>(client =>
    client.BaseAddress = new Uri(
        builder.Configuration.GetSection("AuthGwBaseAddress").Value ??
        throw new InvalidOperationException("Missing configuration value for Auth GW API base address")
    )
);

builder.Services.AddHttpClient<IJobsInFinlandApiClient, JobsInFinlandApiClient>(client =>
    client.BaseAddress = new Uri(
        builder.Configuration.GetSection("JobsInFinland:ApiBaseAddress").Value ??
        throw new InvalidOperationException("Missing configuration value for Jobs in Finland API base address")
    )
);

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}



// Paths that are allowed to be accessed without authorization
List<string> allowedRequestPaths = new List<string> { "/wake-up" };

app.UseAuthGwHeaderValidation(options =>
{
    var optionsRequiredHeaders = options.RequiredHeaders;
    optionsRequiredHeaders.Add("authorization");
    options.AllowedRequestPaths = allowedRequestPaths;
});
if (!app.Environment.IsEnvironment("Local"))
{
    app.UseAuthGwAuthorization(options =>
    {
        options.AllowedRequestPaths = allowedRequestPaths;
    });
}

app.MapPost("test/lassipatanen/Job/JobPosting", async (
        IValidator<JobsPostingRequest> validator,
        JobsPostingRequest query,
        [FromServices] IJobsInFinlandApiClient client) =>
    {
        var validationResult = validator.Validate(query);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(errors: validationResult.ToDictionary(), statusCode: 422);
        }

        IList<Job> queryResult;

        try
        {
            queryResult = await client.GetJobsAsync(query);
        }
        catch (HttpRequestException e)
        {
            var statusCode = 500;
            if (e.StatusCode != null) statusCode = (int)e.StatusCode;

            return Results.Problem(e.ToString(), statusCode: statusCode);
        }


        IJobPostingMapper mapper = new JobPostingMapper();
        var jobs = mapper.From(queryResult);

        var response = new JobPostingResponse
        {
            Results = jobs,
            TotalCount = jobs.Count
        };

        return Results.Ok(response);
    })
    .Produces<JobPostingResponse>()
    .Produces(401)
    .Produces<ValidationProblemDetails>(422)
    .Produces(500)
    .WithName("FindJobPostings");

app.MapGet("/wake-up", () =>
{
    return Task.FromResult(Results.Ok());
})
    .Produces(200)
    .WithName("WakeUp");

app.Run();
