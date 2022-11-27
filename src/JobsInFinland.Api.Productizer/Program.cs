using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Client;
using JobsInFinland.Api.Productizer.Middleware;
using JobsInFinland.Api.Productizer.Models.Request;
using JobsInFinland.Api.Productizer.Models.Testbed;
using JobsInFinland.Api.Productizer.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
builder.Services.AddSingleton<IJobsInFinlandApiClient, JobsInFinlandApiClient>();

//builder.Services.AddControllers();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthGwHeaderValidation(options =>
{
    var optionsRequiredHeaders = options.RequiredHeaders;
    optionsRequiredHeaders.Add("authorization");
    optionsRequiredHeaders.Add("x-authorization-provider");
});
app.UseAuthGwAuthorization();

app.MapPost("test/lassipatanen/Job/JobPosting", async (
        HttpRequest request,
        JobsRequest query,
        [FromServices] IJobsInFinlandApiClient client) =>
    {
        IList<Job> queryResult;

        try
        {
            queryResult = await client.GetJobsAsync(query);
        }
        catch (HttpRequestException e)
        {
            var statusCode = 500;
            if (e.StatusCode != null) statusCode = (int)e.StatusCode;

            return Results.StatusCode(statusCode);
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
    .Produces(500)
    .WithName("FindJobPostings");

app.Run();
