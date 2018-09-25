using InfoSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.App.DataBase.Context
{
    public class InfoSystemDbContext : DbContext
    {
        public InfoSystemDbContext() { } 
        public InfoSystemDbContext(DbContextOptions<InfoSystemDbContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseNpgsql("User ID=postgres;Password=danon999;Host=localhost;Port=5432;Database=InfoSystem.app;"); // connectionStr?
            //base.OnConfiguring(optionsBuilder);
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
