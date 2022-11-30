using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

internal class ClusteringBuilder
{
    private List<Category> _categories = new();
    private Position _position = new();
    private List<Tag> _tags = new();

    public ClusteringBuilder WithCategories(List<Category> value)
    {
        _categories = value;
        return this;
    }

    public ClusteringBuilder WithTags(List<Tag> value)
    {
        _tags = value;
        return this;
    }

    public ClusteringBuilder WithPosition(Position value)
    {
        _position = value;
        return this;
    }

    public Clustering Build()
    {
        return new Clustering(_categories, _tags, _position);
    }
}
