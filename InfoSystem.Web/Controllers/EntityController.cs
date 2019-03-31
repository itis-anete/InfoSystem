using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.XPath;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
//	[Authorize]
	[Route("api/[controller]/[action]")]
	public class EntityController : Controller
	{
		/// <inheritdoc />
		public EntityController()
		{
			_repository = new EntityDomainService();
		}

		/// <summary>
		/// Add a new instance of type <paramref name="typeName"/>.
		/// </summary>
		/// <param name="typeName">Entity type name.</param>\
		/// <param name="requiredAttributeValue">Value of required property</param>
		/// <returns>ActionResult, depending on operation result and added value.</returns> 
        [HttpPost]
		public IActionResult Add([FromQuery] string typeName, string requiredAttributeValue)
		{
//			var authResult =
//				await AuthenticationHttpContextExtensions.AuthenticateAsync(HttpContext,
//					JwtBearerDefaults.AuthenticationScheme);
//			HttpContext.User = authResult.Principal;
			
			var addedEntity = _repository.Add(typeName, requiredAttributeValue);
			if (addedEntity == null)
				return StatusCode(500);
			return Ok(addedEntity);
		}

		/// <summary>
		/// Deletes an instance.
		/// </summary>
		/// <param name="id">Instance's id.</param>
		/// <returns>IActionResult depending on result.</returns>
		[HttpDelete]
		public IActionResult Delete([FromQuery] int id)
		{
			return !_repository.Delete(id) ? StatusCode(500) : Ok();
		}

		/// <summary>
		/// Gets entity by it's id.
		/// </summary>
		/// <param name="id">Id of an entity instance.</param>
		/// <returns>Entity instance.</returns>
		[HttpGet]
		public IActionResult GetById([FromQuery] int id)
		{
			try
			{
				var entity = _repository.GetById(id);
				if (entity == null)
					return StatusCode(500);
				return Ok(entity);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Get all instances of one type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IActionResult GetByTypeId([FromQuery] int typeId)
		{
			try
			{
				var entities = _repository.GetByTypeId(typeId);
				return Ok(entities);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		/// <summary>
		/// Get all instances of one type.
		/// </summary>
		/// <param name="typeName">Entity type name.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IActionResult GetByTypeName([FromQuery] string typeName)
		{
			try
			{
				var entities = _repository.GetByTypeName(typeName);
				return Ok(entities);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return StatusCode(500, e.Message);
			}
		}

		private readonly EntityDomainService _repository;
	}
}