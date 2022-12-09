using System.Text;
using JobsInFinland.Api.Productizer.Models.Request;

namespace JobsInFinland.Api.Productizer.Client;

public class RequestUriBuilder
{
    public enum Direction
    {
        Ascending,
        Descending
    }

    private readonly Dictionary<string, string> _options = new();
    private string? _category;
    private string? _city;
    private string _endpoint = "";
    private int? _limit;
    private int _offset;
    private string? _order;
    private string? _sorting;

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

    public RequestUriBuilder WithSorting(string value, Direction direction = Direction.Ascending)
    {
        var sorting = direction switch
        {
            Direction.Descending => $"-{value}",
            _ => value
        };
        _sorting = sorting;
        return this;
    }

    public RequestUriBuilder OrderBy(string value, Direction direction = Direction.Ascending)
    {
        var order = direction switch
        {
            Direction.Descending => $"-{value}",
            _ => value
        };
        _order = order;
        return this;
    }

    public RequestUriBuilder WithCity(string value)
    {
        _city = value;
        return this;
    }

    public RequestUriBuilder WithCategory(string value)
    {
        _category = value;
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

        // Meta and Offset are always set
        builder.Append($"{_endpoint}?meta=true&offset={_offset}");

        // Custom search params
        if (_limit != null) builder.Append($"&limit={_limit}");
        if (_city != null) builder.Append($"&city={_city}");
        if (_category != null) builder.Append($"&category={_category}");
        if (_sorting != null) builder.Append($"&sort={_sorting}");
        if (_order != null) builder.Append($"&order={_order}");

        // Query keyword params
        if (_options.Count <= 0) return builder.ToString();

        foreach (var option in _options)
        {
            var param = $"&{option.Key}={option.Value}";
            builder.Append(param);
        }

        // TODO: URL encode string
        return builder.ToString();
    }
}

