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
    public class ProductsController : ControllerBase, IController<Product>
    {
        private readonly IProductRepository _repository;

        public ProductsController(IUnitOfWork uof)
        {
            _repository = uof.ProductRepos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _repository.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] string name)
        {
            _repository.Add(new Product(name));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            _repository.Add(new Product(name) {Id = id});
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}