using InfoSystem.Core.Entities.Basic;

namespace InfoSystem.Infrastructure
{
	public static class SqlOptions
	{
		public static string GenerateCreateTableScript(string typeName) =>
			string.Format("CREATE TABLE" + "\"{0}\"(" +
			              $"\"id\" serial NOT NULL," +
			              $"\"key\" text NULL," +
			              $"\"value\" text NULL," +
			              $"\"typeid\" integer NOT NULL," +
			              $"\"entityid\" integer NOT NULL," +
			              "CONSTRAINT \"PK_{0}\" PRIMARY KEY (\"id\")," +
			              "CONSTRAINT \"FK_{0}_Types_typeid\" " +
			              $"FOREIGN KEY (\"typeid\") REFERENCES \"Types\" (\"Id\") ON DELETE CASCADE," +
			              "CONSTRAINT \"FK_{0}_Entities_entityid\" " +
			              $"FOREIGN KEY (\"entityid\") REFERENCES \"Entities\" (\"Id\") ON DELETE CASCADE" +
			              $");", typeName);

		public static string GenerateInsertIntoScript(string typeName, Attribute newAttribute) =>
			$"INSERT INTO {typeName} (key,value,typeid,entityid) " +
			$"VALUES ('{newAttribute.Key}','{newAttribute.Value}',{newAttribute.TypeId},{newAttribute.EntityId});";
		
		public static string GenerateSelectScript(string typeName) => $"SELECT * FROM \"{typeName}\"";

		public static string GenerateSelectWhereScript(string typeName, string predicate) => $"SELECT * FROM {typeName} WHERE {predicate};";

		public static string GenerateUpdateScript(string typeName, string newValue, int attributeId) =>
			$"UPDATE {typeName} SET value = \'{newValue}\' WHERE id = {attributeId};";
	}
}