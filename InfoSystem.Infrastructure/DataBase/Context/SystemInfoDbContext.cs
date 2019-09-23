using System;
using InfoSystem.Core;
using InfoSystem.Core.Entities;
using InfoSystem.Core.Entities.Basic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InfoSystem.Infrastructure.DataBase.Context
{
    public class InfoSystemDbContext : DbContext
    {
        private string _connectionString;

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EntityType> Types { get; set; }
        public DbSet<User> Users { get; set; }

        public InfoSystemDbContext()
        {
            _connectionString = GetConnString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().HasIndex(e => e.TypeId);
            modelBuilder.Entity<EntityType>().HasIndex(t => t.Name);
            modelBuilder.Entity<User>().HasIndex(u => u.Login);
        }
        
        private static string GetConnString()
        {
            var url = Environment.GetEnvironmentVariable("CONNSTRING");
            if (!string.IsNullOrEmpty(url))
                return url;
        
            url = new Core.ConfigurationProvider().Configuration["ConnectionString"];
            return url;
        }
    }
}