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
    private string? _query;
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

    /// <summary>
    ///     Sort by field name
    ///     Available values : title, employer.name, schedule.publish, location.city, location.area
    /// </summary>
    /// <param name="value"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
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

    /// <summary>
    ///     Sort order
    ///     Available values : -1, 1
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public RequestUriBuilder OrderBy(Direction direction = Direction.Ascending)
    {
        var order = direction switch
        {
            Direction.Descending => -1,
            _ => 1
        };
        _order = order.ToString();
        return this;
    }

    /// <summary>
    ///     List of filtering cities separated by comma
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public RequestUriBuilder WithCity(string value)
    {
        _city = value;
        return this;
    }

    /// <summary>
    ///     List of filtering categories separated by comma
    ///     Available values : ict, engineering, academic, health, sales, service, administration, finance, hr, manufacturing,
    ///     management
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public RequestUriBuilder WithCategory(string value)
    {
        _category = value;
        return this;
    }

    /// <summary>
    ///     Free-text query which targets the title, description, location, employer and category fields
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public RequestUriBuilder WithQuery(string value)
    {
        _query = value;
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
        if (_query != null) builder.Append($"&query={_query}");
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






