using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;


namespace BuberDinner.Domain.UserAggregate.ValueObjjects;

public sealed class UserId : ValueObjectClass
{
    public Guid Value { get; private set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
