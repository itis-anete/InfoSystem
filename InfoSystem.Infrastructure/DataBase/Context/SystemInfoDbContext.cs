using System.IO;
using InfoSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.Infrastructure.DataBase.Context
{
    public class InfoSystemDbContext : DbContext
    {
        public InfoSystemDbContext()
        {
        }

//        public InfoSystemDbContext(DbContextOptions<InfoSystemDbContext> opt) : base(opt)
//        {
//
//        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _connectionString = File.ReadAllLines("connectionString.txt")[0];
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Values> Values { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MarketProduct> MarketProducts { get; set; }
        public DbSet<User> Users { get; set; }


        private string _connectionString;
    }
}