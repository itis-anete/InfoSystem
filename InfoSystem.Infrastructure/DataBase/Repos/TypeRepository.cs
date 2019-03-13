using System;
using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
			try
			{
				var entityEntry = _context.Types.Add(new EntityType(newTypeName));

				var formattableString = string.Format("CREATE TABLE" + "\"{0}\"(" +
				                                      $"\"Id\" serial NOT NULL," +
				                                      $"\"Key\" text NULL," +
				                                      $"\"Value\" text NULL," +
				                                      $"\"TypeId\" integer NOT NULL," +
				                                      $"\"EntityId\" integer NOT NULL," +
				                                      "CONSTRAINT \"PK_{0}\" PRIMARY KEY (\"Id\")," +
				                                      "CONSTRAINT \"FK_{0}_Types_AttributeId\" " +
				                                      $"FOREIGN KEY (\"TypeId\") REFERENCES \"Types\" (\"Id\") ON DELETE CASCADE," +
				                                      "CONSTRAINT \"FK_{0}_Entities_EntityId\" " +
				                                      $"FOREIGN KEY (\"EntityId\") REFERENCES \"Entities\" (\"Id\") ON DELETE CASCADE" +
				                                      $");", newTypeName);
				_context.Database.ExecuteSqlCommand(new RawSqlString(formattableString));
				_context.SaveChanges();
				return entityEntry.Entity;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<EntityType> Get() => _context.Types;

		public EntityType GetById(int id) => _context.Types.Find(id);

		private readonly InfoSystemDbContext _context;
	}
}