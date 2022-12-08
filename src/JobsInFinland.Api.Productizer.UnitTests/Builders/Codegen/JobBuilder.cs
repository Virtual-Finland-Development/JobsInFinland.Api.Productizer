using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

public class JobBuilder
{
    private Clustering _clustering = new ClusteringBuilder().Build();
    private string _description = "Job Description";
    private Employer _employer = new EmployerBuilder().Build();
    private string _externalUrl = "external url dot com";
    private string _id = "069c2d8e-70c9-11ed-a1eb-0242ac120002";
    private string _imageUrl = "image url dot png";
    private Location _location = new LocationBuilder().Build();
    private Schedule _schedule = new ScheduleBuilder().Build();
    private Source _source = new SourceBuilder().Build();
    private Status _status = new StatusBuilder().Build();
    private string _title = "Job Title";

    public JobBuilder WithClustering(Clustering value)
    {
        _clustering = value;
        return this;
    }

    public JobBuilder WithDescription(string value)
    {
        _description = value;
        return this;
    }

    public JobBuilder WithEmployer(Employer value)
    {
        _employer = value;
        return this;
    }

    public JobBuilder WithExternalUrl(string value)
    {
        _externalUrl = value;
        return this;
    }

    public JobBuilder WithId(string value)
    {
        _id = value;
        return this;
    }

    public JobBuilder WithImageUrl(string value)
    {
        _imageUrl = value;
        return this;
    }

    public JobBuilder WithSchedule(Schedule value)
    {
        _schedule = value;
        return this;
    }

    public JobBuilder WithSource(Source value)
    {
        _source = value;
        return this;
    }

    public JobBuilder WithStatus(Status value)
    {
        _status = value;
        return this;
    }

    public JobBuilder WithTitle(string value)
    {
        _title = value;
        return this;
    }

    public JobBuilder WithLocation(Location value)
    {
        _location = value;
        return this;
    }

    public Job Build()
    {
        return new Job(_id, _title, _description, _imageUrl, _externalUrl, _employer, _location, _source, _schedule,
            _clustering, _status);
    }
}
