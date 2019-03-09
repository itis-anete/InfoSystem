using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("[controller]/[action]")]
	public class EntityController : Controller
	{
		/// <inheritdoc />
		public EntityController()
		{
			_repository = new EntityRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Add a new instance of type <paramref name="typeName"/>.
		/// </summary>
		/// <param name="typeName">Entity type name.</param>
		[HttpPost]
		public void Add(string typeName)
		{
			_repository.Add(typeName);
		}

		/// <summary>
		/// Gets entity by it's id.
		/// </summary>
		/// <param name="id">Id of an entity instance.</param>
		/// <returns>Entity instance.</returns>
		[HttpGet]
		public Entity Get([FromQuery] int id)
		{
			return _repository.GetById(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeId"></param>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<Entity> GetByType([FromQuery] int typeId)
		{
			return _repository.GetByTypeId(typeId);
		}

		private readonly EntityRepository _repository;
	}
}