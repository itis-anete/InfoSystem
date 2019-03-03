using InfoSystem.Core;
using InfoSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.Infrastructure.DataBase.Context
{
    public class InfoSystemDbContext : DbContext
    {
        public InfoSystemDbContext()
        {
            _connectionString = new ConfigurationProvider().Configuration["ConnectionString"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Values> Values { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MarketProduct> MarketProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EntityProperty> EntityProperties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }

        private string _connectionString;
    }
}