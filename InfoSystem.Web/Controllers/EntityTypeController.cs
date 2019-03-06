using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class EntityTypeController : Controller
    {
        public EntityTypeController()
        {
            _repository = new TypeRepository(new InfoSystemDbContext());
        }

        [HttpGet]
        public IEnumerable<EntityType> Get()
        {
            return _repository.Get();
        }

        private readonly TypeRepository _repository;
    }
}