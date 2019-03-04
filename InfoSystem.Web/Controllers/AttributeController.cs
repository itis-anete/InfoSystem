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
			_repository.Add(new Atttribute() { Name = attributeName}, typeName);
		}

		private readonly AttributeRepository _repository;
	}
}