using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class ReservationId : ValueObjectClass
{
    public Guid Value { get; private set; }

    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public static ReservationId Create(Guid value)
    {
        return new ReservationId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
