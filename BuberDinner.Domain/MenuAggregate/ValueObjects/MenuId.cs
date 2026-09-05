using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObjectClass
{
    public Guid Value { get; private set; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
