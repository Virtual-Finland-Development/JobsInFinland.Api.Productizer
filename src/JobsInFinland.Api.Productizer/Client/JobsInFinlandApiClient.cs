using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Models.Request;
using JobsInFinland.Api.Productizer.Services;

namespace JobsInFinland.Api.Productizer.Client;

internal class JobsInFinlandApiClient : IJobsInFinlandApiClient
{
    private readonly HttpClient _client;
    private readonly ILocationCodeMapper _locationCodeMapper;

    public JobsInFinlandApiClient(HttpClient client, ILocationCodeMapper locationCodeMapper)
    {
        _client = client;
        _locationCodeMapper = locationCodeMapper;
    }

    public async Task<IList<Job>> GetJobsAsync(JobsRequest jobsRequest)
    {
        var cityNames = _locationCodeMapper.GetNamesFromCodes(jobsRequest.Location.Municipalities);
        string? cities = null;
        if (cityNames.Any()) cities = string.Join(",", cityNames);

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


