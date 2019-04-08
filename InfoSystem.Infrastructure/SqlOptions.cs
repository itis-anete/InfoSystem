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

        public static string GenerateCreateAttributesTableScript(string typeName) =>
            string.Format("CREATE TABLE" + "\"{0}attributes\"(" +
                          $"\"id\" serial NOT NULL," +
                          $"\"key\" text NULL," +
                          $"\"value\" text NULL," +
                          $"CONSTRAINT \"PK_{{0}}attributes\" PRIMARY KEY (\"id\"));", typeName);

        public static string GenerateInsertIntoAttributesScript(string typeName, string key, string propertyName) =>
            $"INSERT INTO {typeName}attributes (key,value) " +
            $"VALUES ('{key}','{propertyName}');";

        public static string GenerateDeleteScript(string typeName, int attributeId) =>
            $"DELETE FROM {typeName} WHERE id={attributeId};";

        public static string GenerateInsertIntoScript(string typeName, Property newProperty) =>
            $"INSERT INTO {typeName} (key,value,typeid,entityid) " +
            $"VALUES ('{newProperty.Key}','{newProperty.Value}',{newProperty.TypeId},{newProperty.EntityId});";

        public static string GenerateSelectScript(string typeName) => $"SELECT * FROM \"{typeName}\"";

        public static string GenerateSelectWhereScript(string typeName, string predicate) =>
            $"SELECT * FROM {typeName} WHERE {predicate};";

        public static string GenerateUpdateScript(string typeName, string newValue, int attributeId) =>
            $"UPDATE {typeName} SET value = \'{newValue}\' WHERE id = {attributeId};";
    }
}