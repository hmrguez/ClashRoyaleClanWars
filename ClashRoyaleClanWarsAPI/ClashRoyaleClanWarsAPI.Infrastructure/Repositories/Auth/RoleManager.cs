using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Auth
{
    internal class RoleManager : BaseRepository<RoleModel, Guid>, IRoleManager
    {
        public RoleManager(ClashRoyaleDbContext context) : base(context)
        {
        }

        public async Task<RoleModel> GetRoleByNameAsync(string name)
        {
            return await _context.Roles.SingleOrDefaultAsync(r => r.Name == name)
            ?? throw new RoleNotFoundException(name);
        }
    }
}
