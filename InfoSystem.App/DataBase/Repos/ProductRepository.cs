using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.Entities;

namespace InfoSystem.App.DataBase.Repos
{
    public class ProductRepository : IProductRepository
    {
        private readonly InfoSystemDbContext _context;

        public ProductRepository(InfoSystemDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(Product newProduct)
        {
            //if (_context.Products.Any(p => p.Id == newProduct.Id))
            //    throw new ArgumentException();
            _context.Products.AddAsync(newProduct);
        }

        public void Delete(int id) => _context.Products.Remove(_context.Products.Find(id));
        public IEnumerable<Product> Get() => _context.Products.OrderBy(p => p);
        public Product Get(int id) => _context.Products.Find(id);
    }
}