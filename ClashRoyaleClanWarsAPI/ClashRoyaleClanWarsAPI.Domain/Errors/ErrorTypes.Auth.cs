using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Domain.Errors;

public static partial class ErrorTypes
{
    public static class Auth
    {
        public static Error UsernameNotFound() => new(ErrorCode.UsernameNotFound, "Username does not exist");
        public static Error DuplicateUsername() => new(ErrorCode.DuplicateUsername, "Username already exists");
        public static Error InvalidCredentials() => new(ErrorCode.InvalidCredentials, "InvalidCredentials");
        public static Error InvalidPassword() => new(ErrorCode.InvalidPassword, "Invalid password");
    }
}
