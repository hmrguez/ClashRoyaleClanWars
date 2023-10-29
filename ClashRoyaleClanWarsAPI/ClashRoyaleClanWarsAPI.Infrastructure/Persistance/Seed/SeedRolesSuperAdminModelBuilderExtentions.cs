using ClashRoyaleClanWarsAPI.Application.Auth.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Seed;

public static class SeedRolesSuperAdminModelBuilderExtentions
{
    public static void SeedRoles(this ModelBuilder builder, string superAdminPSW)
    {

        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Name = UserRoles.ADMIN,
                NormalizedName = UserRoles.ADMIN.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole
            {
                Name = UserRoles.USER,
                NormalizedName = UserRoles.USER.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole
            {
                Name = UserRoles.SUPERADMIN,
                NormalizedName = UserRoles.SUPERADMIN.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);

        var passwordHasher = new PasswordHasher<IdentityUser>();

        IdentityUser superadmin = new()
        {
            UserName = "superadmin",
            NormalizedUserName = "SUPERADMIN",
        };

        builder.Entity<IdentityUser>().HasData(superadmin);



        List<IdentityUserRole<string>> userRoles = new();

        superadmin.PasswordHash = passwordHasher.HashPassword(superadmin, superAdminPSW);

        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = superadmin.Id,
            RoleId = roles.First(q => q.Name == UserRoles.SUPERADMIN).Id
        });


        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

    }
}
