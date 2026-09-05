using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating(int value) : ValueObjectClass
{
    public int Value { get; private set; } = value;

    public static Rating Create(int value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
