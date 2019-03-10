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
		/// <param name="value">Value, example: { "attributeId":"4", "content":"Это же название!", "entityId":"6"}</param>
		/// <returns>Added value</returns>
		[HttpPost]
		public IActionResult Add([FromBody] Value value)
		{
			_valueRepository.Add(value);
			var entity = _entityRepository.GetById(value.EntityId);
			value.Attribute = _attributeRepository.GetById(entity.TypeId, value.AttributeId);

			return Ok(value);
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
		/// <returns></returns>
		[HttpPut]
		public IActionResult EditValue([FromBody] Value editedValue)
		{
			if (!_valueRepository.Update(editedValue))
				return BadRequest();
			return Ok(editedValue);
		}

		private readonly IValuesRepository _valueRepository;
		private readonly IAttributeRepository _attributeRepository;
		private readonly IEntityRepository _entityRepository;
	}
}