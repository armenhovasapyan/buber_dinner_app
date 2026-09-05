using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjjects;

namespace BuberDinner.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = [];

    private readonly List<DinnerId> _dinnerIds = [];

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Uri ProfileImage { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public UserId UserId { get; private set; }

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId,
        AverageRating averageRating)
        : base(HostId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = averageRating;
    }

    public static Host Create(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId)
    {
        return new Host(
            HostId.Create(userId),
            firstName,
            lastName,
            profileImage,
            userId,
            AverageRating.CreateNew());
    }
}
