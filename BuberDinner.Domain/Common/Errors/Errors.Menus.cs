using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Menus
    {
        public static Error DuplicateMenu => Error.Conflict(
            code: "Menu.DuplicateMenu",
            description: "Menu is already in use."
        );

        public static Error InvalidCredentials => Error.Validation(
            code: "Menu.InvalidCredentials",
            description: "Invalid credentials."
        );
    }
}
