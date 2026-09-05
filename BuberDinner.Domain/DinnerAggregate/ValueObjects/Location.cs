using ValueObjectClass = BuberDinner.Domain.Common.Models.ValueObject;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObjectClass
{
    public string Name { get; private set; }

    public string Address { get; private set; }

    public string Latitude { get; private set; }

    public string Longitude { get; private set; }

    private Location(string name, string address, string latitude, string longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(string name, string address, string latitude, string longitude)
    {
        return new(name, address, latitude, longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}
