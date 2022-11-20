using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.Client;

internal class JobsInFinlandApiClient : IJobsInFinlandApiClient
{
    private readonly HttpClient _client;

    public JobsInFinlandApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<IList<Job>?> GetJobsAsync()
    {
        var response = await _client.GetAsync("jobs?offset=0&limit=2");
        var result = await response.Content.ReadFromJsonAsync<List<Job>>();

        var jobs = new List<Job>();
        if (result == null) return jobs;
        jobs = result;

        return jobs;
    }
}
