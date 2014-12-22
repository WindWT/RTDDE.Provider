using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SQLite;
using System.Reflection;
using RTDDE.Provider.MasterData;
using RTDDE.Provider.Enums;

namespace RTDDE.Provider
{
    public static class DAL
    {
        private static string _connectionString = "Data Source=RTD_TW.db";
        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        static DAL()
        {
        }

        /// <summary>
        /// 执行SQL获取单条数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static T Get<T>(string sql)
        {
            return Get<T>(sql, null);
        }

        /// <summary>
        /// 执行SQL获取单条数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">SQL参数List</param>
        /// <returns></returns>
        public static T Get<T>(string sql, List<SQLiteParameter> paras)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                if (paras != null)
                {
                    foreach (var para in paras)
                    {
                        cmd.Parameters.Add(para);
                    }
                }

                object o = cmd.ExecuteScalar();
                return (T)Convert.ChangeType(o, typeof(T));
            }
        }

        [Obsolete()]
        public static DataTable GetDataTable(string sql)
        {
            return GetDataTable(sql, null);
        }
        [Obsolete()]
        public static DataTable GetDataTable(string sql, List<SQLiteParameter> paras)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                if (paras != null)
                {
                    foreach (var para in paras)
                    {
                        cmd.Parameters.Add(para);
                    }
                }

                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL获取引用类型数据
        /// </summary>
        /// <typeparam name="T">引用类型</typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static T ToSingle<T>(string sql) where T : class,new()
        {
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();

            T result = new T();
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string[] names = GetColumnNames(reader);
                        for (int i = 0; i < names.Length; i++)
                        {
                            string name = names[i];
                            object value = reader.GetValue(i);
                            if (typeof(T).IsUseProperty())
                            {
                                PropertyInfo property = properties.First(o => o.Name == name);
                                property.SetValue(result, Convert.ChangeType(value, property.PropertyType), null);
                            }
                            else
                            {
                                FieldInfo field = fields.First(o => o.Name == name);
                                field.SetValue(result, Convert.ChangeType(value, field.FieldType));
                            }
                        }
                    }
                    else
                    {
                        result = null;
                    }
                }
            }

            return result;
        }

        public static List<T> ToList<T>(string sql) where T : class,new()
        {
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();

            List<T> list = new List<T>();
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    string[] names = GetColumnNames(reader);
                    while (reader.Read())
                    {
                        T obj = new T();
                        for (int i = 0; i < names.Length; i++)
                        {
                            string name = names[i];
                            object value = reader.GetValue(i);
                            if (typeof(T).IsUseProperty())
                            {
                                PropertyInfo property = properties.First(o => o.Name == name);
                                property.SetValue(obj, Convert.ChangeType(value, property.PropertyType), null);
                            }
                            else
                            {
                                FieldInfo field = fields.First(o => o.Name == name);
                                field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
                            }
                        }
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public static List<T> ToAllList<T>() where T : class, new()
        {
            return ToAllList<T>(string.Empty);
        }
        public static List<T> ToAllList<T>(string orderField) where T : class, new()
        {
            return ToAllList<T>(new string[] { orderField });
        }
        public static List<T> ToAllList<T>(string[] orderFieldStrings) where T : class, new()
        {
            string tableName = Converter.Type2Enum(typeof(T)).ToString();
            string orderString = string.Join(",", orderFieldStrings);
            return ToList<T>(string.Format("SELECT * FROM {0} ORDER BY {1}", tableName, orderString));
        }
        public static void FromSingle<T>(T obj) where T : class,new()
        {
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();

            string tableName = Converter.Type2Enum(typeof(T)).ToString();
            string[] columnNames = GetColumnNames(typeof(T));
            string pkName = GetColumnPKName(typeof(T));

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteTransaction trans = connection.BeginTransaction())
                {
                    SQLiteCommand createTableCmd = new SQLiteCommand(connection);
                    createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + "(";

                    foreach (string name in columnNames)
                    {
                        createTableCmd.CommandText += name;
                        if (String.Compare(name, pkName, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            createTableCmd.CommandText += " PRIMARY KEY,";
                        }
                        else
                        {
                            createTableCmd.CommandText += ",";
                        }
                    }
                    createTableCmd.CommandText = createTableCmd.CommandText.TrimEnd(',');
                    createTableCmd.CommandText += ");";
                    createTableCmd.ExecuteNonQuery();

                    SQLiteCommand upsertRowCmd = new SQLiteCommand(connection);
                    upsertRowCmd.CommandText = "INSERT OR REPLACE INTO " + tableName + "(";
                    StringBuilder sqlColumnName = new StringBuilder();
                    StringBuilder sqlColumnValue = new StringBuilder();
                    foreach (string name in columnNames)
                    {
                        string columnName = name;
                        object columnValue = typeof(T).IsUseProperty() ? properties.First(o => o.Name == name).GetValue(obj, null) : fields.First(o => o.Name == name).GetValue(obj);
                        sqlColumnName.Append(columnName);
                        sqlColumnName.Append(",");
                        sqlColumnValue.Append("@" + columnName);
                        sqlColumnValue.Append(",");
                        SQLiteParameter param = new SQLiteParameter(columnName, columnValue);
                        upsertRowCmd.Parameters.Add(param);
                    }
                    upsertRowCmd.CommandText += sqlColumnName.ToString();
                    upsertRowCmd.CommandText = upsertRowCmd.CommandText.TrimEnd(',');
                    upsertRowCmd.CommandText += ") VALUES (";
                    upsertRowCmd.CommandText += sqlColumnValue.ToString();
                    upsertRowCmd.CommandText = upsertRowCmd.CommandText.TrimEnd(',');
                    upsertRowCmd.CommandText += ");";
                    upsertRowCmd.ExecuteNonQuery();
                    //System.Diagnostics.Debug.WriteLine(upsertRowCmd.CommandText);

                    trans.Commit();
                }
            }
        }

        public static void FromList<T>(List<T> list) where T : class,new()
        {
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();

            string tableName = Converter.Type2Enum(typeof(T)).ToString();
            string[] columnNames = GetColumnNames(typeof(T));
            string pkName = GetColumnPKName(typeof(T));

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteTransaction trans = connection.BeginTransaction())
                {
                    SQLiteCommand createTableCmd = new SQLiteCommand(connection);
                    createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + "(";

                    foreach (string name in columnNames)
                    {
                        createTableCmd.CommandText += name;
                        if (String.Compare(name, pkName, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            createTableCmd.CommandText += " PRIMARY KEY,";
                        }
                        else
                        {
                            createTableCmd.CommandText += ",";
                        }
                    }
                    createTableCmd.CommandText = createTableCmd.CommandText.TrimEnd(',');
                    createTableCmd.CommandText += ");";
                    createTableCmd.ExecuteNonQuery();

                    foreach (T obj in list)
                    {
                        SQLiteCommand upsertRowCmd = new SQLiteCommand(connection);
                        upsertRowCmd.CommandText = "INSERT OR REPLACE INTO " + tableName + "(";
                        StringBuilder sqlColumnName = new StringBuilder();
                        StringBuilder sqlColumnValue = new StringBuilder();
                        foreach (string name in columnNames)
                        {
                            string columnName = name;
                            object columnValue = typeof(T).IsUseProperty() ? properties.First(o => o.Name == name).GetValue(obj, null) : fields.First(o => o.Name == name).GetValue(obj);
                            sqlColumnName.Append(columnName);
                            sqlColumnName.Append(",");
                            sqlColumnValue.Append("@" + columnName);
                            sqlColumnValue.Append(",");
                            SQLiteParameter param = new SQLiteParameter(columnName, columnValue);
                            upsertRowCmd.Parameters.Add(param);
                        }
                        upsertRowCmd.CommandText += sqlColumnName.ToString();
                        upsertRowCmd.CommandText = upsertRowCmd.CommandText.TrimEnd(',');
                        upsertRowCmd.CommandText += ") VALUES (";
                        upsertRowCmd.CommandText += sqlColumnValue.ToString();
                        upsertRowCmd.CommandText = upsertRowCmd.CommandText.TrimEnd(',');
                        upsertRowCmd.CommandText += ");";
                        upsertRowCmd.ExecuteNonQuery();
                        //System.Diagnostics.Debug.WriteLine(upsertRowCmd.CommandText);
                    }
                    trans.Commit();
                }
            }
        }

        public static void DropTable(string tableName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(String.Format("DROP TABLE IF EXISTS {0}", tableName), connection);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 从数据库中获取表列名
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static string[] GetColumnNames(SQLiteDataReader reader)
        {
            int count = reader.FieldCount;
            string[] names = new string[count];
            for (int i = 0; i < count; i++)
            {
                names[i] = reader.GetName(i);
            }
            return names;
        }

        /// <summary>
        /// 从实体中获取表列名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string[] GetColumnNames(Type type)
        {
            FieldInfo[] fields = type.GetFields();
            PropertyInfo[] properties = type.GetProperties();

            List<string> names = new List<string>();
            names.AddRange(type.IsUseProperty()
                ? properties.Select(property => property.Name)
                : fields.Select(field => field.Name));
            return names.ToArray();
        }

        /// <summary>
        /// 从实体中获取表主键列名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetColumnPKName(Type type)
        {
            FieldInfo[] fields = type.GetFields();
            PropertyInfo[] properties = type.GetProperties();

            string name = "id";
            if (type.IsUseProperty())
            {
                foreach (PropertyInfo property in properties)
                {
                    object[] attrs = property.GetCustomAttributes(typeof(DALColumnAttribute), true);
                    if (attrs.Length > 0)
                    {
                        DALColumnAttribute attr = attrs[0] as DALColumnAttribute;
                        if (attr != null && attr.PrimaryKey == true)
                        {
                            name = property.Name;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (FieldInfo field in fields)
                {
                    object[] attrs = field.GetCustomAttributes(typeof(DALColumnAttribute), true);
                    if (attrs.Length > 0)
                    {
                        DALColumnAttribute attr = attrs[0] as DALColumnAttribute;
                        if (attr != null && attr.PrimaryKey == true)
                        {
                            name = field.Name;
                            break;
                        }
                    }
                }
            }
            return name;
        }
        private static bool IsUseProperty(this Type type)
        {
            bool result = false;
            object[] typeattrs = type.GetCustomAttributes(typeof(DALAttribute), true);
            if (typeattrs.Length > 0)
            {
                DALAttribute attr = typeattrs[0] as DALAttribute;
                if (attr != null)
                {
                    result = attr.UseProperty;
                }
            }
            return result;
        }
    }

    public class DALAttribute : Attribute
    {
        public bool UseProperty { get; set; }
    }
    public class DALColumnAttribute : Attribute
    {
        public bool PrimaryKey { get; set; }
    }
}
