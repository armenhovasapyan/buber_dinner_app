using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjjects;

namespace BuberDinner.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private User(string firstName, string lastName, string email, string password, UserId? userId = null) : base(userId ?? UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(
            firstName,
            lastName,
            email,
            password);
    }
}
