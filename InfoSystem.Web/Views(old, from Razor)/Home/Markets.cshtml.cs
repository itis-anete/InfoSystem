using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InfoSystem.Web.Views.Home
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