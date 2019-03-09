using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("[controller]/[action]")]
	public class TypeController : Controller
	{
		/// <inheritdoc />
		public TypeController()
		{
			_repository = new TypeRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Gets entity type specified by it's id.
		/// </summary>
		/// <param name="id">Type's id.</param>
		/// <returns>ActionResult, containing json with type.</returns>
		[HttpGet]
		public IActionResult Get(int id)
		{
			var type = _repository.GetById(id);
			return Json(JsonConvert.SerializeObject(type));
		}

		private readonly TypeRepository _repository;
	}
}