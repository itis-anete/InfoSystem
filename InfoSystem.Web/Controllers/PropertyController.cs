using InfoSystem.Core.Entities.Basic;
using InfoSystem.Sockets.Services;
using InfoSystem.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	//[Authorize]
	[BadRequestExceptionFilter]
	[Route("api/[controller]/[action]")]
	public class PropertyController : Controller
	{
		private readonly PropertyDomainService _service;

		/// <inheritdoc />
		public PropertyController(PropertyDomainService service)
		{
			_service = service;
		}

		/// <summary>
		/// Add a new Property to database.
		/// </summary>
		/// <param name="newProperty">New Property instance.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpPost]
		public IActionResult Add([FromBody] Property newProperty)
		{
			var addedProperty = _service.Add(newProperty) ?? throw new AdditionException();
			return Ok(addedProperty);
		}

        /// <summary>
        /// Removes Property.
        /// </summary>
        /// <param name="typeId">EntityType id.</param>
        /// <param name="propertyId">Instance id.</param>
        /// <returns>IActionResult depending on result of operation.</returns>
        [HttpDelete]
		public IActionResult Delete([FromQuery] int typeId, int propertyId)
		{
			if (!_service.Delete(typeId, propertyId)) throw new DeletionException();
			return Ok();
		}


		/// <summary>
		/// Get system attribute value for type. Default attributeName is "display".
		/// </summary>
		/// <param name="typeName"></param>
		/// <param name="attributeName"></param>
		/// <returns>Attribute value, property key.</returns>
		[HttpGet]
		public string GetAttributeValue(string typeName, string attributeName) =>
			_service.GetAttributeValue(typeName, attributeName);

		/// <summary>
		/// Gets Properties list of one instance.
		/// </summary>
		/// <param name="entityId">Entity instance id.</param>
		/// <param name="typeId">Entity's type id.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpGet]
		public IActionResult GetByEntityId([FromQuery] int entityId, int typeId)
		{
			var properties = _service.GetByEntityId(entityId, typeId);
			return Ok(properties);
		}

		/// <summary>
		/// Get property value for choosen entity.
		/// </summary>
		/// <param name="typeName"></param>
		/// <param name="entityId"></param>
		/// <param name="propertyName"></param>
		/// <returns>IActionResult, StatusCode 500 or property object.</returns>
		[HttpGet]
		public IActionResult GetByPropertyName(string typeName, int entityId, string propertyName)
		{
			var property = _service.GetByPropertyName(propertyName, typeName, entityId)
			               ?? throw new ReceiveException("No such property!");
			return Ok(property);
		}

		/// <summary>
		/// Gets all Properties of all entities in one type.
		/// </summary>
		/// <param name="entityId">Entity's id.</param>
		/// <param name="typeName">EntityType name.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpGet]
		public IActionResult GetByTypeName([FromQuery] int entityId, string typeName)
		{
			var properties = _service.GetByTypeName(entityId, typeName);
			return Ok(properties);
		}

		/// <summary>
		/// Gets all Properties that refers to type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Properties refering to type collection.</returns>
		[HttpGet]
		public IActionResult GetPropertiesByTypeId([FromQuery] int typeId)
		{
			var properties = _service.GetTypePropertiesById(typeId);
			return Ok(properties);
		}

		/// <summary>
		/// Update Property value.
		/// </summary>
		/// <param name="typeId">Property's type id.</param>
		/// <param name="newValue">New value.</param>
		/// <param name="propertyId">Property's id.</param>
		/// <returns>IActionResult, containing either updatedProperty or error status code.</returns>
		[HttpPost]
		public IActionResult Update(int typeId, string newValue, int propertyId)
		{
			var updatedProperty = _service.Update(typeId, newValue, propertyId) ?? throw new UpdateException();
			return Ok(updatedProperty);
		}
	}
}