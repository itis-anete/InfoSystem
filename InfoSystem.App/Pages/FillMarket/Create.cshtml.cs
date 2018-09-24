using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoSystem.App.DataBase.Context;
using InfoSystem.Infrastructure.Entities;

namespace InfoSystem.App.Pages.FillMarket
{
    public class CreateModel : PageModel
    {
        private readonly InfoSystem.App.DataBase.Context.InfoSystemDbContext _context;

        public CreateModel(InfoSystem.App.DataBase.Context.InfoSystemDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MarketId"] = new SelectList(_context.Markets, "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MarketProduct MarketProduct { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MarketProducts.Add(MarketProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}