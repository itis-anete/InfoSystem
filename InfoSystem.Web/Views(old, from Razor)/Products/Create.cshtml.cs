using System.Threading.Tasks;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InfoSystem.Web.Views.Products
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
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}