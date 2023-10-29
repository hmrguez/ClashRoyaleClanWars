using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class CardRepository : BaseRepository<CardModel, int>, ICardRepository
{
    public CardRepository(ClashRoyaleDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name)
    {
        return await _context.Cards.Where(c => c.Name!.Contains(name)).ToListAsync();
    }
}
