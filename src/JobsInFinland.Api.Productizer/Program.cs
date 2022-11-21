using JobsInFinland.Api.Productizer.Client;
using JobsInFinland.Api.Productizer.Models.Testbed;
using JobsInFinland.Api.Productizer.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapPost("jobs", async ([FromServices] IJobsInFinlandApiClient client) =>
{
    var response = await client.GetJobsAsync();

    if (response == null) return new List<JobPosting>();

    IJobPostingMapper mapper = new JobPostingMapper();
    var jobs = mapper.From(response);

    return jobs;
}).Produces<JobPosting>().Produces(401).Produces(500);

app.Run();
