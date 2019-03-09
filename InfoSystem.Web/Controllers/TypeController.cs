using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
		public IActionResult Get(int id)
		{
			var type = _repository.GetById(id);
			return Json(JsonConvert.SerializeObject(type));
		}

		private readonly TypeRepository _repository;
	}
}