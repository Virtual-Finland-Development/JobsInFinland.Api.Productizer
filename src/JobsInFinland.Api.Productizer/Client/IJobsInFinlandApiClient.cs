using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.Client;

internal interface IJobsInFinlandApiClient
{
    Task<IList<Job>> GetJobsAsync();
}
