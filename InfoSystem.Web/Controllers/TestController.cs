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
			_repository.NewAdd("danontable");
		}

		[HttpGet]
		public void GetAttrbiutes()
		{
			_attributeRepository.Get();
		}

		private readonly TypeRepository _repository;
		private readonly AttributeRepository _attributeRepository;
	}
}