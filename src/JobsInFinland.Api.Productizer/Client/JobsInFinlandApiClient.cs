using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Models.Request;

namespace JobsInFinland.Api.Productizer.Client;

internal class JobsInFinlandApiClient : IJobsInFinlandApiClient
{
    private readonly HttpClient _client;

    public JobsInFinlandApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<IList<Job>> GetJobsAsync(JobsRequest jobsRequest)
    {
        string? cities = null;
        if (jobsRequest.Location.Municipalities.Any())
        {
            cities = string.Join(",", jobsRequest.Location.Municipalities);
        }

        var requestUri = new RequestUriBuilder()
            .WithEndpoint("jobs")
            .WithPaging(jobsRequest.Paging)
            .WithQuery(jobsRequest.Query)
            .WithCity(cities)
            .WithSorting("schedule.publish")
            .OrderBy(RequestUriBuilder.Direction.Descending)
            .Build();

        var response = await _client.GetAsync(requestUri);
        var result = await response.Content.ReadFromJsonAsync<GetJobsResponse>();

        var jobs = new List<Job>();
        if (result == null) return jobs;
        jobs = result.Records;

        return jobs;
    }
}

