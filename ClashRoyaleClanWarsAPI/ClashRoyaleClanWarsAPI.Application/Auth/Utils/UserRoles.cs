namespace ClashRoyaleClanWarsAPI.Application.Auth.Utils;

public class UserRoles
{
    public const string USER = "User";
    public const string ADMIN = "Admin";
    public const string SUPERADMIN = "SuperAdmin";

    public static string MapRole(RoleEnum role)
    {
        return role switch
        {
            RoleEnum.User => USER,
            RoleEnum.Admin => ADMIN,
            RoleEnum.SuperAdmin => SUPERADMIN,
            _ => throw new ArgumentException(nameof(role)),
        };
    }
}
