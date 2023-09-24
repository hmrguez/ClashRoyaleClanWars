using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class CardService : ICardService<CardModel>
    {
        private readonly DataContext _context;
        public CardService(DataContext context) 
        {
            _context = context;
        }

        public async Task AddAllCards()
        {
            _context.Structures.AddRange(CardsUpload.StructureCards.ToArray());
            _context.Troops.AddRange(CardsUpload.TroopsCards.ToArray());
            _context.Spells.AddRange(CardsUpload.SpellCards.ToArray());

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name)
        {
            if (_context.Cards == null) throw new ModelNotFoundException<CardModel>();

            return await _context.Cards.Where(c => c.Name.Contains(name)).ToListAsync();
        }

    }
}
