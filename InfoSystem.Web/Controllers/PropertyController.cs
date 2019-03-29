using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("api/[controller]/[action]")]
	public class PropertyController : Controller
	{
		/// <inheritdoc />
		public PropertyController()
		{
			_repository = new PropertyDomainService();
		}

		/// <summary>
		/// Add a new Property to database.
		/// </summary>
		/// <param name="newProperty">New Property instance.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpPost]
		public IActionResult Add([FromBody] Property newProperty)
		{
			var addedProperty = _repository.Add(newProperty);
			if (addedProperty == null)
				return StatusCode(500);
			return Ok(addedProperty);
		}

		/// <summary>
		/// Removes Property.
		/// </summary>
		/// <param name="typeName">EntityType name.</param>
		/// <param name="propertyId">Instance id.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpDelete]
		public IActionResult Delete([FromQuery] string typeName, int propertyId) =>
			!_repository.Delete(typeName, propertyId) ? StatusCode(500) : Ok();

		/// <summary>
		/// Gets all Properties that refers to type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Properties refering to type collection.</returns>
		[HttpGet]
		public IActionResult GetPropertiesByTypeId([FromQuery] int typeId)
		{
			try
			{
				var Propertys = _repository.GetTypePropertiesById(typeId);
				return Ok(Propertys);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Gets Properties list of one instance.
		/// </summary>
		/// <param name="entityId">Entity instance id.</param>
		/// <param name="typeId">Entity's type id.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpGet]
		public IActionResult GetByEntityId([FromQuery] int entityId, int typeId)
		{
			try
			{
				var properties = _repository.GetByEntityId(entityId, typeId);
				return Ok(properties);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
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
			try
			{
				var properties = _repository.GetByTypeName(entityId, typeName);
				return Ok(properties);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Update Property value.
		/// </summary>
		/// <param name="typeName">Property's type name.</param>
		/// <param name="newValue">New value.</param>
		/// <param name="propertyId">Property's id.</param>
		/// <returns>IActionResult, containing either updatedProperty or error status code.</returns>
		[HttpPost]
		public IActionResult Update(string typeName, string newValue, int propertyId)
		{
			var updatedProperty = _repository.Update(typeName, newValue, propertyId);
			if (updatedProperty == null)
				return StatusCode(500);
			return Ok(updatedProperty);
		}

		private readonly PropertyDomainService _repository;
	}
}