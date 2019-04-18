using System;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Sockets.Services;
using InfoSystem.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql;


namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	//[Authorize]
	[BadRequestExceptionFilter]
	[Route("api/[controller]/[action]")]
	public class TypeController : Controller
	{
		private readonly TypeDomainService _service;

		/// <inheritdoc />
		public TypeController(TypeDomainService service)
		{
			_service = service;
		}

		/// <summary>
		/// Adds a new entity type.
		/// </summary>
		/// <param name="typeName">Name of a new type.</param>
		/// <param name="requiredProperty">Key of required property for attributes</param>
		/// <returns>ActionResult that refers to operation result.</returns>
		[HttpPost]
		public IActionResult Add([FromQuery] string typeName, string requiredProperty)
		{
			EntityType addedType;
			try
			{
				addedType = _service.Add(typeName, requiredProperty);
			}
			catch (NpgsqlException e)
			{
				Console.WriteLine(e);
				return Conflict(e.Message);
			}

			return Ok(addedType);
		}

		/// <summary>
		/// Gets all entity type's
		/// </summary>
		/// <returns>EntityTypes's collection.</returns>
		[HttpGet]
		public IActionResult Get()
		{
			var types = _service.Get();
			return Ok(types);
		}

		/// <summary>
		/// Gets entity type specified by it's id.
		/// </summary>
		/// <param name="id">Type's id.</param>
		/// <returns>EntityType object</returns>
		[HttpGet]
		public IActionResult GetById(int id)
		{
			var type = _service.GetById(id) ?? throw new ReceiveException();
			return Ok(type);
		}
	}
}