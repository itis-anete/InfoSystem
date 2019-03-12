using InfoSystem.Core;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>();
            modelBuilder.Entity<Entity>().HasIndex(e => e.TypeId);
//            modelBuilder.Entity<Attribute>().HasIndex(a => a.Name);
//            modelBuilder.Entity<Attribute>().Property(a => a.ValueType).HasConversion<string>();
            modelBuilder.Entity<EntityType>().HasIndex(t => t.Name);
//            modelBuilder.Entity<Value>().HasIndex(v => v.EntityId);
//            modelBuilder.Entity<Value>().HasIndex(v => v.AttributeId);
        }

        public DbSet<Entity> Entities { get; set; }
//        public DbSet<Attribute> Attributes { get; set; }
//        public DbSet<Value> Values { get; set; }
        public DbSet<EntityType> Types { get; set; }

        private string _connectionString;
    }
}