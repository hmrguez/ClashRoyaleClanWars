using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleClanWarsAPI.Data
{
    public class IdentityDataSeeder
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly string[] _roles;
        public IdentityDataSeeder(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roles = new string[] { UserRoles.SUPERADMIN, UserRoles.ADMIN, UserRoles.USER };
            _configuration = configuration;
        }

        public async Task SeedAsync()
        {
            var tasks = new List<Task>();

            foreach (var role in _roles)
                tasks.Add(CreateRoleAsync(new IdentityRole(role)));

            await Task.WhenAll(tasks);

            var superAdminUserPassword = _configuration["SuperAdmin:Psw"];
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin",
            };

            await CreateUserAsync(superAdminUser, superAdminUserPassword!);

            if (!await _userManager.IsInRoleAsync(superAdminUser, UserRoles.SUPERADMIN))
                await _userManager.AddToRoleAsync(superAdminUser, UserRoles.SUPERADMIN);
            

        }
        private async Task CreateRoleAsync(IdentityRole role)
        {
            if (!(await _roleManager.RoleExistsAsync(role.Name!)))
                await _roleManager.CreateAsync(role);
        }

        private async Task CreateUserAsync(IdentityUser user, string password)
        {
            var exists = await _userManager.FindByNameAsync(user.UserName!);
            if (exists == null)
                await _userManager.CreateAsync(user, password);
        }
    }
}
