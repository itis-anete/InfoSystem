using InfoSystem.Core;
using InfoSystem.Core.Entities;
using InfoSystem.Core.Entities.Basic;
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
        public DbSet<Atttribute> Properties { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<EntityType> Types { get; set; }

        private string _connectionString;
    }
}