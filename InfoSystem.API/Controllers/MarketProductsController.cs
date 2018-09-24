using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.App.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.Entities;
using InfoSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.API.Controllers
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
        public ActionResult<IEnumerable<MarketProduct>> Get()
        {
            return _repository.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MarketProduct> Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] string name)
        {
            _repository.Add(new MarketProduct());
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
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