using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjjects;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : AggregateRootId<string>
{
    public override string Value { get; protected set; }

    private HostId(string value)
    {
        Value = value;
    }

    public static HostId Create(UserId userId)
    {
        return new HostId($"Host_{userId.Value}");
    }

    public static HostId Create(string hostId)
    {
        return new HostId(hostId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
