using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.Entities;

namespace InfoSystem.App.Pages.FillMarket
{
    public class DetailsModel : PageModel
    {
        private readonly InfoSystem.App.DataBase.Context.InfoSystemDbContext _context;

        public DetailsModel(InfoSystem.App.DataBase.Context.InfoSystemDbContext context)
        {
            _context = context;
        }

        public MarketProduct MarketProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MarketProduct = await _context.MarketProduct
                .Include(m => m.Market)
                .Include(m => m.Product).FirstOrDefaultAsync(m => m.Id == id);

            if (MarketProduct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
