using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoSystem.App.DataBase.Context;
using InfoSystem.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem.App.Pages
{
    public class MarketsModel : PageModel
    {
        private readonly InfoSystemDbContext dbContext;

        public MarketsModel(InfoSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            this.Markets = this.dbContext.Markets.ToList();
        }

        public IEnumerable<Market> Markets { get; set; }
    }
}