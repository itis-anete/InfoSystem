using System;
using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InfoSystem.Infrastructure.DataBase.Repos
{
	public class TypeRepository
	{
		public TypeRepository(InfoSystemDbContext dbContext)
		{
			_context = dbContext;
		}

		public IEnumerable<EntityType> Get()
		{
//			new Database
//			var x = 1;
//			var contextDatabase =  _context.Database.
//			_context.Query<Attri>().Load().ToList();
//			return null;
//			var x12345 = _context.Model.GetEntityTypes();
//			var type = Type.GetType("d4n0n_myself");
////			var dbQuery = _context.Query<ModelType>();
////			var fromSql = dbQuery.FromSql("SELECT * FROM pg_catalog.pg_tables");
//
//			foreach (var x in fromSql)
//			{
//				Console.WriteLine(x);
//			}
//			return null;

			return _context.Types;
		}

		public EntityType GetById(int id)
		{
			return _context.Types.Find(id);
		}

//	    public EntityType GetByTypeName(string typeName)
//	    {
//	        return _context.Types.FirstOrDefault(x => x.Name == typeName);
//	    }

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
				                                      "CONSTRAINT \"PK_{0}\" PRIMARY KEY (\"Id\")" +
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

		private readonly InfoSystemDbContext _context;
	}
}