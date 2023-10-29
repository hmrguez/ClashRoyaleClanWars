using AutoMapper;
using ClashRoyaleClanWarsAPI.Application.Auth;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Auth.User;
using ClashRoyaleClanWarsAPI.Application.Auth.Utils;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Auth;

internal sealed class AccountRepository : IAccountRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtTokenProvider _jwtTokenProvider;
    private readonly IMapper _mapper;

    public AccountRepository(UserManager<IdentityUser> userManager, IMapper mapper, IJwtTokenProvider jwtTokenProvider, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _jwtTokenProvider = jwtTokenProvider;
        _mapper = mapper;
        _roleManager = roleManager;
    }

    public async Task<LoginResponse> LoginUserAsync(LoginModel loginModel)
    {
        var user = await _userManager.FindByNameAsync(loginModel.Username!)
            ?? throw new UsernameNotFoundException();

        var roles = await _userManager.GetRolesAsync(user);

        if (roles.First() == UserRoles.SUPERADMIN)
        {
            var pswHasher = new PasswordHasher<IdentityUser>();
            var result = pswHasher.VerifyHashedPassword(user, user.PasswordHash!, loginModel.Password!);

            if (result == 0)
                throw new InvalidPasswordException();
        }
        else if (!await _userManager.CheckPasswordAsync(user, loginModel.Password!))
            throw new InvalidPasswordException();

        var userModel = _mapper.Map<UserModel>(user);

        return _jwtTokenProvider.CreateToken(userModel, roles);
    }

    public async Task<UserResponse> RegisterUserAsync(RegisterModel registerModel, RoleEnum role)
    {
        if (await UsernameExits(registerModel.Username!))
            throw new DuplicationUsernameException();

        var roleMapped = UserRoles.MapRole(role);

        var identityUser = await CreateUser(registerModel.Username!, registerModel.Password!, roleMapped);

        return UserResponse.Create(identityUser.Id, identityUser.UserName!, roleMapped);
    }

    private async Task<IdentityUser> CreateUser(string username, string password, string role)
    {
        IdentityUser user = new()
        {
            UserName = username,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new UserCreationException();

        if (await _roleManager.RoleExistsAsync(role))
            await _userManager.AddToRoleAsync(user, role);

        return user;
    }
    private async Task<bool> UsernameExits(string username)
        => (await _userManager.FindByNameAsync(username)) is not null;
}
