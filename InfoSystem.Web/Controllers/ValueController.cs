using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfoSystem.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class ValueController : Controller
	{
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

		[HttpGet]
		public Value Get(string attributeName, int entityId)
		{
			return _valueRepository.GetById(entityId, attributeName);
		}

		[HttpGet]
		public IEnumerable<Value> GetByTypeId([FromQuery] int entityId, int typeId)
		{
			return _valueRepository.GetByTypeId(entityId, typeId).ToList();
		}

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