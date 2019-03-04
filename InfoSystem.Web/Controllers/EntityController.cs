using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
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
		public void AddEntity()
		{
			_repository.Add(new Entity());
		}

		[HttpGet]
		public void GetEntity([FromQuery] int id)
		{
			_repository.GetById(id);
		}

		private readonly IBaseRepository<Entity> _repository;
	}
}