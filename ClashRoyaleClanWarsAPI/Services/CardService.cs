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
        public async Task<int> Add(CardModel model)
        {
            _context.Cards.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;

        }

        public async Task AddAllCards()
        {
            _context.Structures.AddRange(CardsUpload.StructureCards.ToArray());
            _context.Troops.AddRange(CardsUpload.TroopsCards.ToArray());
            _context.Spells.AddRange(CardsUpload.SpellCards.ToArray());

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if(_context.Cards == null) throw new ModelNotFoundException<CardModel>();

            CardModel card;

            try
            {
                card = await GetSingleByIdAsync(id);
            }
            catch (IdNotFoundException<CardModel>)
            {
                throw;
            }
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsId(int id)
        {
            if (_context.Cards == null) throw new ModelNotFoundException<CardModel>();

            return await _context.Cards.AllAsync(c=>c.Id==id);
        }

        public async Task<IEnumerable<CardModel>> GetAllAsync()
        {
            if (_context.Cards == null) throw new ModelNotFoundException<CardModel>();

            return await _context.Cards.ToListAsync();
        }

        public async Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name)
        {
            if (_context.Cards == null) throw new ModelNotFoundException<CardModel>();

            return await _context.Cards.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<CardModel> GetSingleByIdAsync(int id)
        {
            if (_context.Cards == null) throw new ModelNotFoundException<CardModel>();

            var card = await _context.Cards.FindAsync(id);

            return card ?? throw new IdNotFoundException<CardModel>(id);    
        }

        public async Task Update(CardModel model)
        {
            if (_context.Cards == null) throw new ModelNotFoundException<CardModel>();
            if (!(await ExistsId(model.Id))) throw new IdNotFoundException<CardModel>(model.Id);

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
