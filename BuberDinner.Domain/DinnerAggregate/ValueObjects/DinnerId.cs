using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObjectClass
{
    public Guid Value { get; private set; }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
