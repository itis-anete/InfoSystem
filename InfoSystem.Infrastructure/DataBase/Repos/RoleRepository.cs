using System;
using System.Linq;
using InfoSystem.Core.Entities;
using InfoSystem.Infrastructure.DataBase.Context;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class RoleRepository 
	{
		private readonly InfoSystemDbContext _context;

		public RoleRepository(InfoSystemDbContext context)
		{
			_context = context;
		}

		public Role Create(string name, bool canRead, bool canWrite)
		{
			try
			{
				var entry = _context.Roles.Add(new Role(name, canRead, canWrite));
				_context.SaveChanges();
				return entry.Entity;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public bool Delete(int roleId)
		{
			try
			{
				_context.Roles.Remove(_context.Roles.Find(roleId));
				_context.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
		}

		public Role GetById(int roleId) => _context.Roles.FirstOrDefault(r => r.Id == roleId);

		public Role Update(Role newRole)
		{
			try
			{
				var role = _context.Roles.FirstOrDefault(r => r.Id == newRole.Id);
				if (role == null) throw new NullReferenceException();
				role.CanRead = newRole.CanRead;
				role.CanWrite = newRole.CanWrite;
				var entry = _context.Roles.Update(role);
				_context.SaveChanges();
				return entry.Entity;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}
	}
}