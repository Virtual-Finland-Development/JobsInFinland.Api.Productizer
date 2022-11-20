using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer;

internal interface IJobsInFinlandApiClient
{
    Task<IList<Job>?> GetJobsAsync();
}
