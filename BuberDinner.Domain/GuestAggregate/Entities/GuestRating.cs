using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

using ErrorOr;

namespace BuberDinner.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; private set; }

    public DinnerId DinnerId { get; private set; }

    public Rating Rating { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private GuestRating(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating) : base(GuestRatingId.CreateUnique())
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
    }

    public static ErrorOr<GuestRating> Create(DinnerId dinnerId, HostId hostId, int rating)
    {
        var ratingValueObject = Rating.Create(rating);

        return new GuestRating(hostId, dinnerId, ratingValueObject);
    }
}
