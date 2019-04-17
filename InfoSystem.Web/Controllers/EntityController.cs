using InfoSystem.Sockets.Services;
using InfoSystem.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Authorize]
	[BadRequestExceptionFilter]
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
			var addedEntity = _service.Add(typeName, requiredAttributeValue) ?? throw new AdditionException();
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
			if (!_service.Delete(id)) throw new DeletionException();
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
			var entity = _service.GetById(id) ?? throw new ReceiveException();
			return Ok(entity);
		}

		/// <summary>
		/// Get all instances of one type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IActionResult GetByTypeId([FromQuery] int typeId)
		{
			var entities = _service.GetByTypeId(typeId);
			return Ok(entities);
		}

		/// <summary>
		/// Get all instances of one type.
		/// </summary>
		/// <param name="typeName">Entity type name.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IActionResult GetByTypeName([FromQuery] string typeName)
		{
			var entities = _service.GetByTypeName(typeName);
			return Ok(entities);
		}

		[HttpGet]
		public IActionResult GetMenu() => Ok(_service.GetMenu());
	}
}