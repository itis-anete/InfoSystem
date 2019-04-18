using InfoSystem.Core.Entities;
using InfoSystem.Sockets.Services;
using InfoSystem.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Authorize]
	[BadRequestExceptionFilter]
	[Route("api/[controller]/[action]")]
	public class RoleController : Controller
	{
		private readonly RoleDomainService _service;

		/// <inheritdoc />
		public RoleController(RoleDomainService service)
		{
			_service = service;
		}

		/// <summary>
		/// Add a new role.
		/// </summary>
		/// <param name="name">Name of the role.</param>
		/// <param name="canRead">Permission to read.</param>
		/// <param name="canWrite">Permission to write.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpPost]
		public IActionResult Create(string name, bool canRead, bool canWrite)
		{
			var newRole = _service.Create(name, canRead, canWrite) ?? throw new AdditionException();
			return Ok(newRole);
		}

		/// <summary>
		/// Removes role by id.
		/// </summary>
		/// <param name="roleId">Role's id.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpDelete]
		public IActionResult Delete(int roleId)
		{
			if (!_service.Delete(roleId)) throw new DeletionException();
			return Ok();
		}

		/// <summary>
		/// Gets role from database by id.
		/// </summary>
		/// <param name="roleId">Role's id.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpGet]
		public IActionResult GetById(int roleId)
		{
			var role = _service.GetById(roleId) ?? throw new ReceiveException();
			return Ok(role);
		}

		/// <summary>
		/// Updated an exising role.
		/// </summary>
		/// <param name="newRole">Existing role object.</param>
		/// <returns>IActionResult depending on result of operation.</returns>
		[HttpGet]
		public IActionResult Update(Role newRole)
		{
			var updatedRole = _service.Update(newRole) ?? throw new UpdateException();
			return Ok(updatedRole);
		}
	}
}