using InfoSystem.Core.Entities;
using InfoSystem.Sockets.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	[Route("[controller]/[action]")]
	public class RoleController : Controller
	{
		public RoleController()
		{
			_service = new RoleDomainService();
		}

		[HttpPost]
		public IActionResult Create(bool canRead, bool canWrite)
		{
			var newRole = _service.Create(canRead, canWrite);
			if (newRole == null)
				return BadRequest();
			return Ok(newRole);
		}

		[HttpDelete]
		public IActionResult Delete(int roleId)
		{
			if (!_service.Delete(roleId))
				return BadRequest();
			return Ok();
		}

		[HttpGet]
		public IActionResult GetById(int roleId)
		{
			var role = _service.GetById(roleId);
			if (role == null)
				return BadRequest();
			return Ok(role);
		}

		[HttpGet]
		public IActionResult Update(Role newRole)
		{
			var updatedRole = _service.Update(newRole);
			if (updatedRole == null)
				return BadRequest();
			return Ok(updatedRole);
		}

		private readonly RoleDomainService _service;
	}
}