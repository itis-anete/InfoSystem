using System;
using System.Collections.Generic;
using InfoSystem.App.DataBase.ReposInterfaces;
using InfoSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _repository;
        
        public UsersController(IUnitOfWork uof)
        {
            _repository = uof.UserRepos;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Create([FromBody] string name)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void Create(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}