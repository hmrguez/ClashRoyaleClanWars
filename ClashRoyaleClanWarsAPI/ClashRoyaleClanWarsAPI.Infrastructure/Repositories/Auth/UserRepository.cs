using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Auth;

internal sealed class UserRepository : BaseRepository<UserModel, Guid>, IUserRepository
{
    private readonly IRoleManager _roleManager;

    public UserRepository(ClashRoyaleDbContext context, IRoleManager roleManager) : base(context)
    {
        _roleManager = roleManager;
    }

    public async Task<UserModel> GetUserByNameAsync(string username)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.UserName == username)
            ?? throw new UsernameNotFoundException();

        return user;
    }
    public override async Task<UserModel> GetSingleByIdAsync(Guid id)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Id == id)
            ?? throw new IdNotFoundException<Guid>(id);

        return user;
    }
    public override async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        var usersResponse = await _context.Users
            .Include(u => u.Role)
            .ToListAsync();

        return usersResponse;
    }
    public async Task<UserModel> Add(string username, string password, RoleModel role)
    {
        UserModel user = UserModel.Create(username, role.Id);

        var passwordHasher = new PasswordHasher<UserModel>();
        user.PasswordHash = passwordHasher.HashPassword(user, password);

        await _context.Users.AddAsync(user);

        await Save();

        return user;
    }
    public async Task Delete(Guid id)
    {
        var user = await _context.Users
            .SingleOrDefaultAsync(u => u.Id == id)
            ?? throw new IdNotFoundException<Guid>(id);

        _context.Users.Remove(user);

        await Save();
    }
    public async Task UpdateRole(Guid id, string role)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Id == id)
            ?? throw new IdNotFoundException<Guid>(id);

        var roleInstance = await _roleManager.GetRoleByNameAsync(role);

        user.Role = roleInstance;

        await _context.SaveChangesAsync();
    }
    public async Task ChangePassword(Guid id, string newPassword)
    {
        var user = await GetSingleByIdAsync(id);

        var pswHasher = new PasswordHasher<UserModel>();

        var hashedPssword = pswHasher.HashPassword(user, newPassword);
        user.PasswordHash = hashedPssword;

        await Save();
    }
}
