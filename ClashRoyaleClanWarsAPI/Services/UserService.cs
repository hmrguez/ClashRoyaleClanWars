using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenCreationService _jwtService;

        public UserService(UserManager<IdentityUser> userManager, ITokenCreationService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public  async Task<User> GetUserAsync(string username)
        {
            var identUser = await _userManager.FindByNameAsync(username) 
                ?? throw new UserNotFoundException();

            return new User { Username = identUser.UserName! };
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterUserModel user)
        {
            if(user is null)
                throw new NullReferenceException($"{nameof(RegisterUserModel)} is null");

            if (user.Password != user.ConfirmPassword)
                return new UserManagerResponse(message: "Confirm password does not match with password", success: false);

            var result = await _userManager.CreateAsync(new IdentityUser()
            {
                UserName = user.Username
            }, user.Password);

            if (!result.Succeeded)
                return new UserManagerResponse(message: "User did not create",
                    success: false, errors: result.Errors);


            return new UserManagerResponse(
                new User { Username = user.Username }, 
                message: "User created successfully", 
                success: true);

        }

        public async Task<LoginResponse> LoginUserAsync(LoginUserModel loginUser)
        {
            if (loginUser is null)
                throw new NullReferenceException($"{nameof(LoginUserModel)} is null");
            
            var user = await _userManager.FindByNameAsync(loginUser.Username)
                ?? throw new UserNotFoundException();

            if (await _userManager.CheckPasswordAsync(user, loginUser.Password))
                throw new InvalidPasswordException();

            return _jwtService.CreateToken(user);

        }
    }
}
