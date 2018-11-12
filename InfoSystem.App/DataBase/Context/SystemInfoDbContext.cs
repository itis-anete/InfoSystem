using System.IO;
using InfoSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.App.DataBase.Context
{
    public class InfoSystemDbContext : DbContext
    {
        public InfoSystemDbContext()
        {
        }

        public InfoSystemDbContext(DbContextOptions<InfoSystemDbContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = File.ReadAllLines("connectionString.txt")[0];
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Values> Values { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MarketProduct> MarketProducts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}