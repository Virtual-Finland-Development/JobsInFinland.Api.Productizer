using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Models.Testbed;
using Location = JobsInFinland.Api.Productizer.Models.Testbed.Location;

namespace JobsInFinland.Api.Productizer;

public class JobPostingMapper : IJobPostingMapper
{
    private const string InformationNotProvided = "Information not provided";

    public List<JobPosting> From(IEnumerable<Job> jobs)
    {
        var mappedJobs = new List<JobPosting>();

        mappedJobs.AddRange(jobs.Select(job => new JobPosting
        {
            Employer = job.Employer.Name,
            Location = new Location
            {
                City = job.Location.City,
                Postcode = string.Empty
            },
            ApplicationUrl = job.ExternalUrl,
            BasicInfo = new BasicInfo
            {
                Description = job.Description,
                Title = job.Title,
                WorkTimeType = InformationNotProvided
            },
            PublishedAt = Convert.ToDateTime(job.Schedule.Publish),
            ApplicationEndDate = DateTime.MinValue
        }));

        return mappedJobs;
    }
}
