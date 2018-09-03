using InfoSystem.App.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.App.DataBase.Context
{
    public class InfoSystemDbContext : DbContext
    {
        public InfoSystemDbContext(DbContextOptions opt) :base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<MarketProduct> MarketProduct { get; set; }
    }
}