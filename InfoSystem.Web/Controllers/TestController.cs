using System.Collections.Generic;
using System.Net;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class TestController : Controller
	{
		public TestController()
		{
			_repository = new TypeRepository(new InfoSystemDbContext());
			_attributeRepository = new AttributeRepository(new InfoSystemDbContext());
		}

		[HttpGet]
		public void Add(string newTypeName)
		{
			_repository.Add(newTypeName);
		}

		[HttpGet]
		public IEnumerable<Attribute> GetAttrbiutes(string typeName)
		{
			return _attributeRepository.Get(typeName);
		}
		
		[HttpGet]
		public void GetAttrbiutesByEntityId(int entityId, string typeName)
		{
			_attributeRepository.GetByEntityId(entityId, typeName);
		}

		private readonly TypeRepository _repository;
		private readonly AttributeRepository _attributeRepository;
	}
}