using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;

namespace InfoSystem.App.Pages.FillMarket
{
    public class IndexModel : PageModel
    {
        private readonly InfoSystemDbContext _context;

        public IndexModel(InfoSystemDbContext context)
        {
            _context = context;
        }

        public IList<MarketProduct> MarketProduct { get;set; }

        public async Task OnGetAsync()
        {
            MarketProduct = await _context.MarketProducts
                .Include(m => m.Market)
                .Include(m => m.Product).ToListAsync();
        }
    }
}
