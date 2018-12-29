using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class MarketRepository : IMarketRepository
    {
        private readonly InfoSystemDbContext _context;

        public MarketRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Market newMarket)
        {
            //if (_context.Markets.Any(x => x.Name == newMarket.Name))
            //    throw new ArgumentException();
            _context.Markets.AddAsync(newMarket);
        }

        public void Delete(int id) => _context.Markets.Remove(_context.Markets.Find(id));
        public IEnumerable<Market> Get() => _context.Markets.OrderBy(m => m);
        public Market Get(int id) => _context.Markets.Find(id);
    }
}