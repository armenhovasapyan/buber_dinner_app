using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : ValueObjectClass
{
    public Guid Value { get; private set; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
