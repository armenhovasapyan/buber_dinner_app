using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjjects;

namespace BuberDinner.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = [];

    private readonly List<DinnerId> _pastDinnerIds = [];

    private readonly List<DinnerId> _pendingDinnerIds = [];

    private readonly List<BillId> _billIds = [];

    private readonly List<MenuReviewId> _menuReviewIds = [];

    private readonly List<GuestRating> _ratings = [];

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Uri ProfileImage { get; private set; }

    public UserId UserId { get; private set; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private Guest(string firstName, string lastName, Uri profileImage, UserId userId, GuestRating? guestRating = null, GuestId? guestId = null)
    : base(guestId ?? GuestId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
    }

    public static Guest Create(string firstName, string lastName, Uri profileImage, UserId userId)
    {
        return new Guest(firstName, lastName, profileImage, userId);
    }
}
