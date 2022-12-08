using System.Globalization;
using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

internal class ScheduleBuilder
{
    private DateTime _expire = new(2023, 12, 1);
    private DateTime _publish = new(2022, 10, 1);

    public ScheduleBuilder WithPublish(DateTime value)
    {
        _publish = value;
        return this;
    }

    public ScheduleBuilder WithExpire(DateTime value)
    {
        _expire = value;
        return this;
    }

    public Schedule Build()
    {
        return new Schedule(
            _publish.ToString(CultureInfo.InvariantCulture),
            _expire.ToString(CultureInfo.InvariantCulture)
        );
    }
}
