using System.Collections.Generic;
using System.Linq;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class TypeRepository : ITypeRepository
	{
		public TypeRepository(InfoSystemDbContext dbContext)
		{
			_context = dbContext;
		}

		public EntityType Add(string newTypeName)
		{
			newTypeName = newTypeName.ToLower();
			if (_context.Types.Any(t => t.Name == newTypeName))
				throw new NpgsqlException("EntityType already exists");
			var entityEntry = _context.Types.Add(new EntityType(newTypeName));
			var sqlQuery = SqlOptions.GenerateCreateTableScript(newTypeName);
			_context.Database.ExecuteSqlCommand(new RawSqlString(sqlQuery));
			_context.SaveChanges();
			return entityEntry.Entity;
		}

		public IEnumerable<EntityType> Get() => _context.Types;

		public EntityType GetById(int id) => _context.Types.Find(id);

		private readonly InfoSystemDbContext _context;
	}
}