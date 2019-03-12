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

		public EntityType Add(string typeName)
		{
			try
			{
				var entityEntry = _context.Types.Add(new EntityType(typeName));
				_context.SaveChanges();
				return entityEntry.Entity;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<EntityType> Get()
		{
//			new Database
//			var x = 1;
//			var contextDatabase =  _context.Database.
//			_context.Query<Attri>().Load().ToList();
			return null;
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
		}

		public EntityType GetById(int id)
		{
			return _context.Types.Find(id);
		}

//	    public EntityType GetByTypeName(string typeName)
//	    {
//	        return _context.Types.FirstOrDefault(x => x.Name == typeName);
//	    }
	    
	     public void NewAdd(string newTypeName)
        {
            #region Scratches

//            var addEntityType = ModelExtensions.AsModel(_context.Model).AddEntityType("newType");
//            var addProperty = addEntityType.AddProperty("Identificator", typeof(string));
//            addEntityType.AddKey(addProperty);
//            addEntityType.AddKey(new Property("Identificator", typeof(string), null, null, addEntityType, ConfigurationSource.Explicit, ConfigurationSource.Explicit));
//            var entityTypes = _context.Model.GetEntityTypes();
//            var creator = (RelationalDatabaseCreator) _context.Database.GetService<IDatabaseCreator>();
//            var generateCreateScript = creator.GenerateCreateScript();

//            CREATE TABLE "Attributes" (
//                "Id" serial NOT NULL,
//            "Name" text NULL,
//            "TypeId" integer NOT NULL,
//            "ValueType" text NOT NULL,
//                CONSTRAINT "PK_Attributes" PRIMARY KEY ("Id")
//                );
//
//            CREATE TABLE "Entities" (
//                "Id" serial NOT NULL,
//            "TypeId" integer NOT NULL,
//                CONSTRAINT "PK_Entities" PRIMARY KEY ("Id")
//                );
//
//            CREATE TABLE "Types" (
//                "Id" serial NOT NULL,
//            "Name" text NULL,
//                CONSTRAINT "PK_Types" PRIMARY KEY ("Id")
//                );
//
//            CREATE TABLE "Values" (
//                "Id" serial NOT NULL,
//            "Content" text NULL,
//            "EntityId" integer NOT NULL,
//            "AttributeId" integer NOT NULL,
//                CONSTRAINT "PK_Values" PRIMARY KEY ("Id"),
//            CONSTRAINT "FK_Values_Attributes_AttributeId" FOREIGN KEY ("AttributeId") REFERENCES "Attributes" ("Id") ON DELETE CASCADE
//                );

            #endregion

            var formattableString = string.Format("CREATE TABLE" + "\"{0}\"(" +
                                                  $"\"Id\" serial NOT NULL," +
                                                  $"\"Key\" text NULL," +
                                                  $"\"Value\" text NULL," +
                                                  $"\"TypeId\" integer NOT NULL," +
                                                  $"\"EntityId\" integer NOT NULL," +
                                                  "CONSTRAINT \"PK_{0}\" PRIMARY KEY (\"Id\")" +
//                                                  "CONSTRAINT \"FK_{0}_Attributes_AttributeId\" " +
//                                                  $"FOREIGN KEY (\"AttributeId\") REFERENCES \"Attributes\" (\"Id\") ON DELETE CASCADE," +
//                                                  "CONSTRAINT \"FK_{0}_Entities_EntityId\" " +
//                                                  $"FOREIGN KEY (\"EntityId\") REFERENCES \"Entities\" (\"Id\") ON DELETE CASCADE" +
                                                  $");", newTypeName);
            _context.Database.ExecuteSqlCommand(new RawSqlString(formattableString));
            _context.SaveChanges();
        }

        private readonly InfoSystemDbContext _context;
	}
}