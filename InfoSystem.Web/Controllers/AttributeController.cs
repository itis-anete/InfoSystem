using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class AttributeController : Controller
	{
		public AttributeController()
		{
			_repository = new AttributeRepository(new InfoSystemDbContext());
		}

		[HttpPost]
		public void Add(string attributeName, string typeName)
		{
			_repository.Add(new Attribute() {Name = attributeName}, typeName);
		}

		[HttpGet]
		public IEnumerable<Attribute> GetTypeAtttributes(string typeName)
		{
			return _repository.GetTypeAttributes(typeName);
		}

	    [HttpGet]
	    public IEnumerable<Attribute> GetByTypeId([FromQuery] int typeId)
	    {
	        return _repository.GetTypeAttributesById(typeId);
	    }

        private readonly AttributeRepository _repository;
	}
}