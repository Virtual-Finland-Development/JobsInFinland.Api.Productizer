using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Models.Request;
using JobsInFinland.Api.Productizer.Services;

namespace JobsInFinland.Api.Productizer.Client;

internal class JobsInFinlandApiClient : IJobsInFinlandApiClient
{
    private readonly HttpClient _client;
    private readonly ICodeMapperFactory _factory;
    private readonly ILogger<JobsInFinlandApiClient> _logger;

    public JobsInFinlandApiClient(HttpClient client, ILogger<JobsInFinlandApiClient> logger, ICodeMapperFactory factory)
    {
        _client = client;
        _logger = logger;
        _factory = factory;
    }

    public async Task<IList<Job>> GetJobsAsync(JobsRequest jobsRequest)
    {
        string? query = null;
        string? cities = null;

        var municipalityCodeMapper = _factory.CreateForMunicipalityCode();
        var municipalityNames = municipalityCodeMapper.GetNamesFromCodes(jobsRequest.Location.Municipalities);

        if (municipalityNames.Any())
            cities = string.Join(",", municipalityNames);

        var occupationCodeMapper = _factory.CreateForOccupationCode();
        var occupationNames = occupationCodeMapper.GetNamesFromCodes(jobsRequest.Requirements.Occupations);

        if (occupationNames.Any())
            query = string.Join(" ", occupationNames);

        if (!string.IsNullOrEmpty(jobsRequest.Query))
            query = $"{query} {jobsRequest.Query}";

        var requestUri = new RequestUriBuilder()
            .WithEndpoint("jobs")
            .WithPaging(jobsRequest.Paging)
            .WithQuery(query)
            .WithCity(cities)
            .WithSorting("schedule.publish")
            .OrderBy(RequestUriBuilder.Direction.Descending)
            .Build();

        _logger.LogInformation("RequestUri is: {RequestUri}", requestUri);

        var response = await _client.GetAsync(requestUri);
        var result = await response.Content.ReadFromJsonAsync<GetJobsResponse>();

        var jobs = new List<Job>();

        if (result == null) return jobs;

        jobs = result.Records;

        return jobs;
    }
}




