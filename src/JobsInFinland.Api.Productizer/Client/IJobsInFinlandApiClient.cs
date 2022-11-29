using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Models.Request;

namespace JobsInFinland.Api.Productizer.Client;

public interface IJobsInFinlandApiClient
{
    Task<IList<Job>> GetJobsAsync(JobsRequest jobsRequest);
}
