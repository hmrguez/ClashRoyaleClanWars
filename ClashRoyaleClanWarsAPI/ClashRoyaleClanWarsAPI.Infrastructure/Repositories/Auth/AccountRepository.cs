using ClashRoyaleClanWarsAPI.Application.Auth;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Auth.Utils;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Auth;

internal sealed class AccountRepository : IAccountRepository
{
    private readonly ClashRoyaleDbContext _context;
    private readonly IRoleManager _roleManager;
    private readonly IPlayerRepository _playerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenProvider _jwtTokenProvider;

    public AccountRepository(IJwtTokenProvider jwtTokenProvider,
                             IPlayerRepository playerRepository,
                             ClashRoyaleDbContext context,
                             IUserRepository userRepository,
                             IRoleManager roleManager)
    {
        _jwtTokenProvider = jwtTokenProvider;
        _playerRepository = playerRepository;
        _context = context;
        _userRepository = userRepository;
        _roleManager = roleManager;
    }

    public async Task<LoginResponse> LoginUserAsync(LoginModel loginModel)
    {
        var user = await _userRepository.GetUserByNameAsync(loginModel.Username!);

        if (!VerifyPassword(user, loginModel.Password!))
            throw new InvalidCredentialException();

        return _jwtTokenProvider.CreateToken(user, user.Role!.Name);
    }

    public async Task<UserResponse> RegisterUserAsync(RegisterModel registerModel, RoleEnum role)
    {
        if (await UsernameExits(registerModel.Username!))
            throw new DuplicationUsernameException();

        if (registerModel.Password != registerModel.ConfirmPassword)
            throw new PasswordsNotMatchException();

        var roleMapped = UserRoles.MapRole(role);

        var appUser = await CreateUser(registerModel.Username!, registerModel.Password!, roleMapped);

        return UserResponse.Create(appUser.Id, appUser.UserName!, roleMapped, appUser.PlayerId);
    }

    private async Task<UserModel> CreateUser(string username, string password, string role)
    {
        var roleInstance = await _roleManager.GetRoleByNameAsync(role);

        var user = await _userRepository.Add(username, password, roleInstance);

        var playerModel = PlayerModel.Create(username);

        var playerId = await _playerRepository.Add(playerModel);

        user.PlayerId = playerId;

        await _context.SaveChangesAsync();

        return user;
    }

    private bool VerifyPassword(UserModel user, string providedPassword)
    {
        var pswHasher = new PasswordHasher<UserModel>();
        var result = pswHasher.VerifyHashedPassword(user, user.PasswordHash, providedPassword);

        return result == PasswordVerificationResult.Success;
    }
    private async Task<bool> UsernameExits(string username)
        => (await _context.Users.Where(u=> u.UserName == username).FirstOrDefaultAsync()) is not null;
}
