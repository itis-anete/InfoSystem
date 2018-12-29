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
    public class UsersController : ControllerBase, IController<User>
    {
        private IUserRepository _repository;

        public UsersController(IUnitOfWork uof)
        {
            _repository = uof.UserRepos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _repository.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] string name)
        {
            _repository.Add(new User(name));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            _repository.Add(new User(name) {Id = id});
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}