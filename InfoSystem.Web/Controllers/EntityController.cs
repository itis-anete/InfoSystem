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
		public void Add(string name)
		{
			_repository.Add(new Entity() { Name = name});
		}

		[HttpGet]
		public void Get([FromQuery] int id)
		{
			_repository.GetById(id);
		}

		private readonly EntityRepository _repository;
	}
}