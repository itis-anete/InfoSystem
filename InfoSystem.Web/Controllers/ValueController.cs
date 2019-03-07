using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class ValueController : Controller
	{
		public ValueController()
		{
			_valueRepository = new ValuesRepository(new InfoSystemDbContext());
			_attributeRepository = new AttributeRepository(new InfoSystemDbContext());
			//_entityRepository = new EntityRepository(new InfoSystemDbContext());
		}

		[HttpPost]
		public void Add(string value, string attributeName, string entityName, int entityId)
		{
			// TODO - entityId = костыль 

			var atttribute = _attributeRepository.GetByName(entityName, attributeName);
			if (atttribute == null)
			{
				Response.StatusCode = 500;
				return;
			}

			_valueRepository.Add(new Value() {AttributeId = atttribute.Id, Content = value, EntityId = entityId});
		}

	 	[HttpGet]
		public Value Get(string attributeName, int entityId)
		{
			return _valueRepository.GetById(entityId, attributeName);
		}

	    [HttpGet]
	    public IEnumerable<Value> GetByTypeId([FromQuery]int entityId, int typeId)
	    {
	        return _valueRepository.GetByTypeId(entityId, typeId).ToList();
	    }

        private readonly ValuesRepository _valueRepository;
		private readonly AttributeRepository _attributeRepository;
		//private readonly EntityRepository _entityRepository;
	}
}