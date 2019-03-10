using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("[controller]/[action]")]
	public class TypeController : Controller
	{
		/// <inheritdoc />
		public TypeController()
		{
			_repository = new TypeRepository(new InfoSystemDbContext());
		}

		[HttpPost]
		public IActionResult Add(string typeName)
		{
			if (!_repository.Add(typeName))
				return BadRequest();
			
			return Ok();
		}
		
		/// <summary>
		/// Gets entity type specified by it's id.
		/// </summary>
		/// <param name="id">Type's id.</param>
		/// <returns>EntityType object</returns>
		[HttpGet]
		public EntityType GetById(int id)
		{
		    return _repository.GetById(id);
		}

        /// <summary>
        /// Gets all entity type's
        /// </summary>
        /// <returns>EntityTypes's collection.</returns>
        [HttpGet]
	    public IEnumerable<EntityType> Get(int id)
	    {
	        return _repository.Get();
	    }

        private readonly TypeRepository _repository;
	}
}