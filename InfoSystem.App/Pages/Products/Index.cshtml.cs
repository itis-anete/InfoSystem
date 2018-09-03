using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSystem.App.DataBase.Context;
using InfoSystem.App.DataBase.Entities;

namespace InfoSystem.App.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly InfoSystem.App.DataBase.Context.InfoSystemDbContext _context;

        public IndexModel(InfoSystem.App.DataBase.Context.InfoSystemDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
