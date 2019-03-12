using System.Net;
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
		public void GetAttrbiutes(string typeName)
		{
			_attributeRepository.Get(typeName);
		}

		private readonly TypeRepository _repository;
		private readonly AttributeRepository _attributeRepository;
	}
}