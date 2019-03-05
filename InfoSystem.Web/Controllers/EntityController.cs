using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class EntityController : Controller
	{
		public EntityController()
		{
			_repository = new EntityRepository(new InfoSystemDbContext());
		}

        [HttpPost]
        public void Add(string typeName)
        {
            _repository.Add(typeName);
        }

        [HttpGet]
		public Entity Get([FromQuery] int id)
		{
            return _repository.GetById(id);
        }

	    [HttpGet]
	    public IEnumerable<Entity> GetByType([FromQuery] int typeId)
	    {
	        return _repository.Get().Where(x => x.TypeId == typeId);
        }

        private readonly EntityRepository _repository;
	}
}