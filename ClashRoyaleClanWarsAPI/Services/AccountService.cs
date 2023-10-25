using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenCreationService _jwtService;

        public AccountService(UserManager<IdentityUser> userManager, ITokenCreationService jwtService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }
        public async Task<RequestResponse<User>> RegisterUserAsync(RegisterModel model)
        {
            if (model is null)
                throw new NullReferenceException($"{nameof(RegisterModel)} is null");

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new RequestResponse<User>(message: "Username already exists", success: false);

            if (model.Password != model.ConfirmPassword)
                return new RequestResponse<User>(message: "Confirm password does not match with password", success: false);

            IdentityUser user = new IdentityUser()
            {
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new RequestResponse<User>(message: "User did not create",
                    success: false);

            if (await _roleManager.RoleExistsAsync(UserRoles.USER))
                await _userManager.AddToRoleAsync(user, UserRoles.USER);

            return new RequestResponse<User>(
                new User { Username = user.UserName, Role = UserRoles.USER },
                message: "User created successfully",
                success: true);

        }

        public async Task<LoginResponse> LoginUserAsync(LoginUserModel loginUser)
        {
            if (loginUser is null)
                throw new NullReferenceException($"{nameof(LoginUserModel)} is null");

            var user = await _userManager.FindByNameAsync(loginUser.Username)
                ?? throw new UserNotFoundException();

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.First() == UserRoles.SUPERADMIN)
            {
                var pswHasher = new PasswordHasher<IdentityUser>();
                var result = pswHasher.VerifyHashedPassword(user, user.PasswordHash!, loginUser.Password);

                if (result == 0)
                    throw new InvalidPasswordException();
            }
            else if (await _userManager.CheckPasswordAsync(user, loginUser.Password))
                throw new InvalidPasswordException();


            return _jwtService.CreateToken(user, roles);

        }

        public async Task<RequestResponse<User>> RegisterAdminAsync(RegisterModel model)
        {
            if (model is null)
                throw new NullReferenceException($"{nameof(RegisterModel)} is null");

            if (await _userManager.FindByNameAsync(model.Username) is null)
                return new RequestResponse<User>(message: "Username already exists", success: false);

            if (model.Password != model.ConfirmPassword)
                return new RequestResponse<User>(message: "Confirm password does not match with password", success: false);


            IdentityUser user = new IdentityUser()
            {
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new RequestResponse<User>(message: "Admin did not create",
                    success: false);

            if (await _roleManager.RoleExistsAsync(UserRoles.ADMIN))
                await _userManager.AddToRoleAsync(user, UserRoles.ADMIN);

            return new RequestResponse<User>(
                new User { Username = user.UserName, Role = UserRoles.ADMIN },
                message: "Admin created successfully",
                success: true);

        }

    }
}
