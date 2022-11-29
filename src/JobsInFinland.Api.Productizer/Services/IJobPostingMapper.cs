using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Models.Testbed;

namespace JobsInFinland.Api.Productizer.Services;

public interface IJobPostingMapper
{
    public List<JobPosting> From(IEnumerable<Job> jobs);
}
