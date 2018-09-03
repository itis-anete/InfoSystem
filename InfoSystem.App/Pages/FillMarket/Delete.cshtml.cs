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
    public class DeleteModel : PageModel
    {
        private readonly InfoSystem.App.DataBase.Context.InfoSystemDbContext _context;

        public DeleteModel(InfoSystem.App.DataBase.Context.InfoSystemDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MarketProduct = await _context.MarketProduct.FindAsync(id);

            if (MarketProduct != null)
            {
                _context.MarketProduct.Remove(MarketProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
