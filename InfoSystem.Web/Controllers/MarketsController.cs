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
    public class MarketsController : ControllerBase, IController<Market>
    {
        private readonly IMarketRepository _repository;
        
        public MarketsController(IUnitOfWork uof)
        {
            _repository = uof.MarketRepos;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Market>> Get()
        {
            return _repository.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Market> Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] string name)
        {
            _repository.Add(new Market(name));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            _repository.Add(new Market(name){Id = id});
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}