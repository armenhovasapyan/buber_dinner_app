using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Price : ValueObjectClass
{
    public decimal Amount { get; private set; }

    public string Currency { get; private set; }

    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(decimal amount, string currency)
    {
        return new(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
