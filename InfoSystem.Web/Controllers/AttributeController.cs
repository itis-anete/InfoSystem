using System;
using System.Collections.Generic;
using System.Linq;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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
			_repository = new AttributeRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Add a new Attribute to database.
		/// </summary>
		/// <param name="newAttribute"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Add(Attribute newAttribute)
		{
			var addedAttribute = _repository.Add(newAttribute);
			if (addedAttribute == null)
				return BadRequest();
			return Ok(addedAttribute);
		}

		/// <summary>
		/// Gets all attributes that refers to type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Attributes refering to type collection.</returns>
		[HttpGet]
		public IActionResult GetAttributesByTypeId([FromQuery] int typeId)
		{
			IEnumerable<Attribute> attributes;
			try
			{
				attributes = _repository.GetTypeAttributesById(typeId);
				if (attributes == null)
					return NotFound();
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
		/// <param name="typeId"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetByEntityId([FromQuery] int entityId, int typeId)
		{
			IEnumerable<Attribute> attributes;
			try
			{
				attributes = _repository.GetByEntityId(entityId, typeId);
				if (attributes == null || !attributes.Any())
					return NotFound();
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
			IEnumerable<Attribute> attributes;
			try
			{
				attributes = _repository.GetByTypeName(entityId, typeName);
				if (attributes == null || !attributes.Any())
					return NotFound();
				return Ok(attributes);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		[HttpPost]
		public IActionResult Update(string typeName, string newValue, int attributeId)
		{
			var updatedAttribute = _repository.Update(typeName, newValue, attributeId);
			if (updatedAttribute == null)
				return BadRequest();
			return Ok(updatedAttribute);
		}

		private readonly IAttributeRepository _repository;
	}
}