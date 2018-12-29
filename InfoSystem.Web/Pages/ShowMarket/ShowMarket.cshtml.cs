using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.App.Pages.ShowMarket
{
    public class ShowMarketModel : PageModel
    {
        private readonly InfoSystemDbContext dbContext;

        public ShowMarketModel(InfoSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int marketId)
        {
            this.Products = this.dbContext.MarketProducts.Where(x => x.MarketId == marketId)
                .Include(x=>x.Product)
                .ToList()
                .Select(x => x.Product);
        }

        public IEnumerable<Product> Products { get; set; }
    }
}