using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Mvc;
using Attribute = InfoSystem.Core.Entities.Basic.Attribute;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("api/[controller]/[action]")]
	public class AttributeController : Controller
	{
		/// <inheritdoc />
		public AttributeController()
		{
			_repository = new AttributeDomainService();
		}

		/// <summary>
		/// Add a new Attribute to database.
		/// </summary>
		/// <param name="newAttribute"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Add([FromBody] Attribute newAttribute)
		{
			var addedAttribute = _repository.Add(newAttribute);
			if (addedAttribute == null)
				return StatusCode(500);
			return Ok(addedAttribute);
		}

		[HttpDelete]
		public IActionResult Delete([FromQuery] string typeName, int attributeId) =>
			!_repository.Delete(typeName, attributeId) ? StatusCode(500) : Ok();

		/// <summary>
		/// Gets all attributes that refers to type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Attributes refering to type collection.</returns>
		[HttpGet]
		public IActionResult GetAttributesByTypeId([FromQuery] int typeId)
		{
			try
			{
				var attributes = _repository.GetTypeAttributesById(typeId);
				return Ok(attributes);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Gets attributes list of one instance.
		/// </summary>
		/// <param name="entityId"></param>
		/// <param name="typeId">Entity's type id.</param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetByEntityId([FromQuery] int entityId, int typeId)
		{
			try
			{
				var attributes = _repository.GetByEntityId(entityId, typeId);
				return Ok(attributes);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Gets all attributes of all entities in one type.
		/// </summary>
		/// <param name="entityId"></param>
		/// <param name="typeName"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetByTypeName([FromQuery] int entityId, string typeName)
		{
			try
			{
				var attributes = _repository.GetByTypeName(entityId, typeName);
				return Ok(attributes);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Update Attribute value.
		/// </summary>
		/// <param name="typeName">Attribute's type name.</param>
		/// <param name="newValue">New value.</param>
		/// <param name="attributeId">Attribute's id.</param>
		/// <returns>IActionResult, containing either updatedAttribute or error status code.</returns>
		[HttpPost]
		public IActionResult Update(string typeName, string newValue, int attributeId)
		{
			var updatedAttribute = _repository.Update(typeName, newValue, attributeId);
			if (updatedAttribute == null)
				return StatusCode(500);
			return Ok(updatedAttribute);
		}

		private readonly AttributeDomainService _repository;
	}
}