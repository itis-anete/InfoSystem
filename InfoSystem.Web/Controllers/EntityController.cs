using System;
using InfoSystem.Sockets.Services;
using InfoSystem.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Authorize]
	[Route("api/[controller]/[action]")]
	public class EntityController : Controller
	{
		private readonly EntityDomainService _service;

		/// <inheritdoc />
		public EntityController(EntityDomainService service)
		{
			_service = service;
		}

		/// <summary>
		/// Add a new instance of type <paramref name="typeName"/>.
		/// </summary>
		/// <param name="typeName">Entity type name.</param>\
		/// <param name="requiredAttributeValue">Value of required property</param>
		/// <returns>ActionResult, depending on operation result and added value.</returns> 
		[HttpPost]
		public IActionResult Add([FromQuery] string typeName, string requiredAttributeValue)
		{
			var addedEntity = _repository.Add(typeName, requiredAttributeValue);
			if (addedEntity == null)
				return StatusCode(500);
			return Ok(addedEntity);
		}

		/// <summary>
		/// Deletes an instance.
		/// </summary>
		/// <param name="id">Instance's id.</param>
		/// <returns>IActionResult depending on result.</returns>
		[HttpDelete]
		public IActionResult Delete([FromQuery] int id)
		{
			return !_service.Delete(id) ? StatusCode(500) : Ok();
		}

		/// <summary>
		/// Gets entity by it's id.
		/// </summary>
		/// <param name="id">Id of an entity instance.</param>
		/// <returns>Entity instance.</returns>
		[HttpGet]
		public IActionResult GetById([FromQuery] int id)
		{
			try
			{
				var entity = _service.GetById(id);
				if (entity == null)
					return StatusCode(500);
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
		public IActionResult GetByTypeId([FromQuery] int typeId)
		{
			try
			{
				var entities = _service.GetByTypeId(typeId);
				return Ok(entities);
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
		/// <param name="typeName">Entity type name.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IActionResult GetByTypeName([FromQuery] string typeName)
		{
			try
			{
				var entities = _service.GetByTypeName(typeName);
				return Ok(entities);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}
		
		public IActionResult GetMenu()
		{
			try
			{
				return Ok(_service.GetMenu());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return Ok(null);
			}
		}
	}
}