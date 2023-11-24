using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Auth.User;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Auth;

internal sealed class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ClashRoyaleDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(UserManager<IdentityUser> userManager, ClashRoyaleDbContext context, IMapper mapper)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponse> GetUserByNameAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username)
            ?? throw new UsernameNotFoundException();

        var role = (await _userManager.GetRolesAsync(user)).First();

        return UserResponse.Create(user.Id, user.UserName!, role);
    }
    public async Task<UserResponse> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id)
            ?? throw new IdNotFoundException<string>(id);

        var role = (await _userManager.GetRolesAsync(user)).First();

        return UserResponse.Create(user.Id, user.UserName!, role);
    }
    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        if (_context.Users == null) throw new ModelNotFoundException(nameof(IdentityUser));

        return await _context.Users
            .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
    public async Task Delete(string id)
    {
        var identUser = await _userManager.FindByIdAsync(id)
            ?? throw new IdNotFoundException<string>(id);

        await _userManager.DeleteAsync(identUser);

        await _context.SaveChangesAsync();
    }
    public async Task UpdateRole(string id, string role)
    {
        var identUser = await _userManager.FindByIdAsync(id)
            ?? throw new IdNotFoundException<string>(id);

        var currentRole = (await _userManager.GetRolesAsync(identUser)).First();

        await _userManager.RemoveFromRoleAsync(identUser, currentRole);

        await _userManager.AddToRoleAsync(identUser, role);

        await _context.SaveChangesAsync();
    }

}
