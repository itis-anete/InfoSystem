using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("api/[controller]/[action]")]
	public class TypeController : Controller
	{
		/// <inheritdoc />
		public TypeController()
		{
			_repository = new TypeRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Adds a new entity type.
		/// </summary>
		/// <param name="typeName">Name of a new type.</param>
		/// <returns>ActionResult that refers to operation result.</returns>
		[HttpPost]
		public IActionResult Add([FromQuery] string typeName)
		{
			var addedType = _repository.Add(typeName);
			if (addedType == null)
				return BadRequest();
			return Ok(addedType);
		}

		/// <summary>
		/// Gets entity type specified by it's id.
		/// </summary>
		/// <param name="id">Type's id.</param>
		/// <returns>EntityType object</returns>
		[HttpGet]
		public EntityType GetById(int id)
		{
			return _repository.GetById(id);
		}

		/// <summary>
		/// Gets all entity type's
		/// </summary>
		/// <returns>EntityTypes's collection.</returns>
		[HttpGet]
		public IEnumerable<EntityType> Get()
		{
			return _repository.Get();
		}

		private readonly TypeRepository _repository;
	}
}