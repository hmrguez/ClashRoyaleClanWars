using ClashRoyaleClanWarsAPI.Application.Auth.Utils;
using ClashRoyaleClanWarsAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Seed;

public static class SeedRolesSuperAdminModelBuilderExtentions
{
    public static void SeedRoles(this ModelBuilder builder, string superAdminPSW)
    {
        var superAdminRole = RoleModel.Create(UserRoles.SUPERADMIN);

        List<RoleModel> roles = new List<RoleModel>()
        {
            RoleModel.Create(UserRoles.ADMIN),
            RoleModel.Create(UserRoles.USER),
            superAdminRole
        };

        builder.Entity<RoleModel>().HasData(roles);

        var passwordHasher = new PasswordHasher<UserModel>();

        UserModel superAdminUser = UserModel.Create("superadmin", superAdminRole.Id);
        
        superAdminUser.PasswordHash = passwordHasher.HashPassword(superAdminUser, superAdminPSW);

        builder.Entity<UserModel>().HasData(superAdminUser);

    }
}
