using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
    public class MarketProductRepository : IMarketProductRepository
    {
        private readonly InfoSystemDbContext _context;

        public MarketProductRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(MarketProduct newMp)
        {
            //if (_context.MarketProducts.Any(mp => mp.Id == newMp.Id))
            //    throw new ArgumentException();
            _context.MarketProducts.AddAsync(newMp);
        }

        public void Delete(int id) => _context.MarketProducts.Remove(_context.MarketProducts.Find(id));
        public IEnumerable<MarketProduct> Get() => _context.MarketProducts.OrderBy(mp => mp);
        public MarketProduct Get(int id) => _context.MarketProducts.Find(id);
    }
}