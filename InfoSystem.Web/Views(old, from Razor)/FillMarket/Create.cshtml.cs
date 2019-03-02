using System.Threading.Tasks;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InfoSystem.Web.Views.FillMarket
{
    public class CreateModel : PageModel
    {
        private readonly InfoSystemDbContext _context;

        public CreateModel(InfoSystemDbContext context)
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