using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSystem.App.DataBase.Context;
using InfoSystem.Infrastructure.Entities;

namespace InfoSystem.App.Pages.FillMarket
{
    public class IndexModel : PageModel
    {
        private readonly InfoSystem.App.DataBase.Context.InfoSystemDbContext _context;

        public IndexModel(InfoSystem.App.DataBase.Context.InfoSystemDbContext context)
        {
            _context = context;
        }

        public IList<MarketProduct> MarketProduct { get;set; }

        public async Task OnGetAsync()
        {
            MarketProduct = await _context.MarketProduct
                .Include(m => m.Market)
                .Include(m => m.Product).ToListAsync();
        }
    }
}
