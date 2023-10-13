using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DataContext _context;

        public UserService(UserManager<IdentityUser> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            var identUser = await _userManager.FindByNameAsync(username) 
                ?? throw new UserNotFoundException();

            var role = (await _userManager.GetRolesAsync(identUser)).First();

            return new User { Username = identUser.UserName!, Role = role};
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            var identUser = await _userManager.FindByIdAsync(id)
                ?? throw new UserNotFoundException();

            var role = (await _userManager.GetRolesAsync(identUser)).First();

            return new User { Username = identUser.UserName!, Role = role };
        }
        public virtual async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            if (_context.Users == null) throw new ModelNotFoundException<IdentityUser>();

            return await _context.Users.ToListAsync();
        }
        public async Task Delete(string id)
        {
            var identUser = await _userManager.FindByIdAsync(id)
                ?? throw new UserNotFoundException();

            await _userManager.DeleteAsync(identUser);

            await _context.SaveChangesAsync();
        }
    }
}
