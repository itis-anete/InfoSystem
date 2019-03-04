using System;
using System.Linq;
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        public TestController()
        {
            _context = new InfoSystemDbContext();
        }
        [HttpGet]
        public void ShowAllAtributesInConsoleByEntityType(string typeName)
        {
            var type = _context.Types.FirstOrDefault(t => typeName == t.Name);
            if (type == null) return;
            Console.WriteLine(type.Name);
            foreach (var atttribute in _context.Atttributes.Where(a => a.TypeId == type.Id))
                Console.WriteLine("\t" + atttribute.Name);
        }

        private readonly InfoSystemDbContext _context;
    }
}