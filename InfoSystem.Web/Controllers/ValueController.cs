using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("[controller]/[action]")]
	public class ValueController : Controller
	{
		/// <inheritdoc />
		public ValueController()
		{
			_valueRepository = new ValuesRepository(new InfoSystemDbContext());
			_attributeRepository = new AttributeRepository(new InfoSystemDbContext());
			_entityRepository = new EntityRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Add a new Value to database.
		/// </summary>
		/// <param name="input">JSON, example: { "attributeId":"4", "content":"Это же название!", "entityId":"6"}</param>
		/// <returns>ActionResult, that indicates success/fail of operation.</returns>
		[HttpPost]
		public IActionResult Add(string input)
		{
			var value = JsonConvert.DeserializeObject<Value>(input);
			var entity = _entityRepository.GetById(value.EntityId);
			value.Attribute = _attributeRepository.GetById(entity.TypeId, value.AttributeId);

			if (value.Attribute == null)
			{
				Response.StatusCode = 500;
				return BadRequest();
			}

			_valueRepository.Add(value);
			return Ok();
		}

		/// <summary>
		/// Gets a value refering to attribute and entity, that contains it.
		/// </summary>
		/// <param name="attributeName">Attribute name.</param>
		/// <param name="entityId">Entity's id, that contains this value</param>
		/// <returns>Value instance.</returns>
		[HttpGet]
		public Value Get(string attributeName, int entityId)
		{
			return _valueRepository.GetById(entityId, attributeName);
		}

		/// <summary>
		/// Gets all values of an entity.
		/// </summary>
		/// <param name="entityId">Entity that contains values.</param>
		/// <returns>Entity's values collection.</returns>
		[HttpGet]
		public IEnumerable<Value> GetEntityValues([FromQuery] int entityId)
		{
			return _valueRepository.GetEntityValues(entityId).ToList();
		}

		/// <summary>
		/// In development.
		/// </summary>
		/// <param name="editedValue"></param>
		/// <returns></returns>
		[HttpPut]
		public IActionResult EditValue([FromBody] Value editedValue)
		{
			// TODO - изменение бд
			editedValue.Attribute = _attributeRepository.GetById(editedValue.AttributeId);
			return Ok(editedValue);
		}

		private readonly ValuesRepository _valueRepository;
		private readonly AttributeRepository _attributeRepository;
		private readonly EntityRepository _entityRepository;
	}
}