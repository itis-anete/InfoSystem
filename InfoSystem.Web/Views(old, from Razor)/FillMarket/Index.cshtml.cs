using System.Collections.Generic;
using System.Threading.Tasks;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.Web.Views.FillMarket
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
