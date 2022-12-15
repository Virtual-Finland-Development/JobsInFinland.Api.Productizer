using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Models.Request;
using JobsInFinland.Api.Productizer.Services;

namespace JobsInFinland.Api.Productizer.Client;

internal class JobsInFinlandApiClient : IJobsInFinlandApiClient
{
    private readonly HttpClient _client;
    private readonly ILogger<JobsInFinlandApiClient> _logger;
    private readonly IMunicipalityCodeMapper _municipalityCodeMapper;
    private readonly IOccupationCodeMapper _occupationCodeMapper;

    public JobsInFinlandApiClient(
        HttpClient client,
        IMunicipalityCodeMapper municipalityCodeMapper,
        IOccupationCodeMapper occupationCodeMapper,
        ILogger<JobsInFinlandApiClient> logger)
    {
        _client = client;
        _municipalityCodeMapper = municipalityCodeMapper;
        _occupationCodeMapper = occupationCodeMapper;
        _logger = logger;
    }

    public async Task<IList<Job>> GetJobsAsync(JobsRequest jobsRequest)
    {
        string? query = null;
        string? cities = null;

        var cityNames = _municipalityCodeMapper.GetNamesFromCodes(jobsRequest.Location.Municipalities);

        if (cityNames.Any())
            cities = string.Join(",", cityNames);

        var occupationNames = _occupationCodeMapper.GetNamesFromCodes(jobsRequest.Occupations);
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


