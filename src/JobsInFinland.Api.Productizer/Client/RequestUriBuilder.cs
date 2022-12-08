using System.Text;
using JobsInFinland.Api.Productizer.Models.Request;

namespace JobsInFinland.Api.Productizer.Client;

public class RequestUriBuilder
{
    private readonly Dictionary<string, string> _options = new();
    private string _endpoint = "";
    private int? _limit;
    private int _offset;

    public RequestUriBuilder WithEndpoint(string value)
    {
        _endpoint = value;
        return this;
    }

    public RequestUriBuilder WithPaging(PagingOptions value)
    {
        _offset = value.Offset;
        _limit = value.Limit;
        return this;
    }

    public RequestUriBuilder WithQueryOption(KeyValuePair<string, string> value)
    {
        _options.Add(value.Key, value.Value);
        return this;
    }

    public string Build()
    {
        var builder = new StringBuilder();
        builder.Append($"{_endpoint}?meta=true&offset={_offset}");

        if (_limit != null)
        {
            builder.Append($"&limit={_limit}");
        }

        if (_options.Count <= 0) return builder.ToString();

        foreach (var option in _options)
        {
            var param = $"&{option.Key}={option.Value}"; // TODO: URL encode these
            builder.Append(param);
        }

        return builder.ToString();
    }
}
