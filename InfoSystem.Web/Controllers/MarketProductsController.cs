using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.DataBase.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketProductsController : ControllerBase, IController<MarketProduct>
    {
        private readonly IMarketProductRepository _repository;

        public MarketProductsController(IUnitOfWork uof)
        {
            _repository = uof.MarketProductRepos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MarketProduct>> GetMP()
        {
            return _repository.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MarketProduct> GetMPById(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void PostMP([FromBody] string name)
        {
            _repository.Add(new MarketProduct());
        }

        [HttpPut("{id}")]
        public void PostMPWithId(int id, [FromBody] string value)
        {
            _repository.Add(new MarketProduct() {Id = id});
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}