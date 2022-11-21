using JobsInFinland.Api.Productizer;
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapPost("jobs", ([FromServices] IJobsInFinlandApiClient client) =>
{
    /*
    var client = new ApiClient("https://jobsinfinland.fi/api/");
    var options = new RequestOptions
    {
        QueryParameters = new Multimap<string, string>
        {
            {
                "offset", "0"
            },
            {
                "limit", "1"
            }
        }
    };
    
    var result = client.Get<Job>("jobs?offset=0&limit=1", options, new Configuration
    {
        BasePath = apiBaseUrl
    });
    */

    var response = client.GetJobsAsync();

    if (response.Result == null) return new List<JobPosting>();

    IJobPostingMapper mapper = new JobPostingMapper();
    var output = mapper.From(response.Result);

    return output;
});

app.Run();
