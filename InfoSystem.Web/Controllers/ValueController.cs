using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("api/[controller]/[action]")]
	public class ValueController : Controller
	{
		/// <inheritdoc />
		public ValueController()
		{
//			_valueRepository = new ValuesRepository(new InfoSystemDbContext());
			_attributeRepository = new AttributeRepository(new InfoSystemDbContext());
			_entityRepository = new EntityRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Add a new Value to database.
		/// </summary>
		/// <param name="value">Value, example: { "attributeId":"4", "content":"Это же название!", "entityId":"6"}</param>
		/// <returns>ActionResult, depending on operation result and added value.</returns>
		[HttpPost]
		public IActionResult Add([FromBody] Value value)
		{
			var addedValue = _valueRepository.Add(value);
			var entity = _entityRepository.GetById(addedValue.EntityId);
			addedValue.Attribute = _attributeRepository.GetById(entity.TypeId, addedValue.AttributeId);

			return Ok(addedValue);
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
		/// Edits existing Value instance.
		/// </summary>
		/// <param name="editedValue"></param>
		/// <returns>ActionResult, depending on operation result and new value.</returns>
		[HttpPut]
		public IActionResult EditValue([FromBody] Value editedValue)
		{
			var updatedValue = _valueRepository.Update(editedValue);
			if (updatedValue == null)
				return BadRequest();
			updatedValue.Attribute = _attributeRepository.GetById(editedValue.AttributeId);
			return Ok(updatedValue);
		}

		private readonly IValuesRepository _valueRepository;
		private readonly IAttributeRepository _attributeRepository;
		private readonly IEntityRepository _entityRepository;
	}
}