using System;
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
	public class EntityController : Controller
	{
		/// <inheritdoc />
		public EntityController()
		{
			_repository = new EntityRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Add a new instance of type <paramref name="typeName"/>.
		/// </summary>
		/// <param name="typeName">Entity type name.</param>
		/// <returns>ActionResult, depending on operation result and added value.</returns> 
		[HttpPost]
		public IActionResult Add([FromQuery] string typeName)
		{
			var addedEntity = _repository.Add(typeName);
			if (addedEntity == null)
				return NotFound();
			return Ok(addedEntity);
		}

		/// <summary>
		/// Deletes an instance.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (!_repository.Delete(id))
				return BadRequest();
			return Ok();
		}

		/// <summary>
		/// Gets entity by it's id.
		/// </summary>
		/// <param name="id">Id of an entity instance.</param>
		/// <returns>Entity instance.</returns>
		[HttpGet]
		public IActionResult GetById([FromQuery] int id)
		{
			Entity entity;
			try
			{
				entity = _repository.GetById(id);
				if (entity == null)
					return NotFound();
				return Ok(entity);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Get all instances of one type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IActionResult GetByType([FromQuery] int typeId)
		{
			IEnumerable<Entity> entities;
			try
			{
				entities = _repository.GetByTypeId(typeId);
				if (entities == null)
					return NotFound();
				return Ok(entities);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		private readonly IEntityRepository _repository;
	}
}