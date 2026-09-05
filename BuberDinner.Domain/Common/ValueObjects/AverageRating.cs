using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating(double value, int numRaiting) : ValueObjectClass
{
    public double Value { get; private set; } = value;

    public int NumRating { get; private set; } = numRaiting;

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public void AddNewRaiting(Rating rating)
    {
        Value = ((Value * NumRating) + rating.Value) / ++NumRating;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
