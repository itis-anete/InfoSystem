using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.XPath;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
//	[Authenticate]
	[Route("api/[controller]/[action]")]
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
		/// <returns>ActionResult, depending on operation result and added value.</returns>
		[HttpPost]
		public async Task<IActionResult> Add([FromQuery] string typeName)
		{
			var authResult =
				await AuthenticationHttpContextExtensions.AuthenticateAsync(HttpContext,
					JwtBearerDefaults.AuthenticationScheme);
			HttpContext.User = authResult.Principal;
			var addedEntity = _repository.Add(typeName);
			if (addedEntity == null)
				return BadRequest();
			return Ok(addedEntity);
		}

		/// <summary>
		/// Gets entity by it's id.
		/// </summary>
		/// <param name="id">Id of an entity instance.</param>
		/// <returns>Entity instance.</returns>
		[HttpGet]
		public Entity Get([FromQuery] int id) => _repository.GetById(id);

		/// <summary>
		/// Get all instances of one type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IEnumerable<Entity> GetByType([FromQuery] int typeId) => _repository.GetByTypeId(typeId);

		private readonly IEntityRepository _repository;
	}
}