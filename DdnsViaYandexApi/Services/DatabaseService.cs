using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using log4net;

namespace Core.Services
{
    public class DatabaseService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DdnsViaYandexApi));

        public static SQLiteCommandBuilder SqLiteCommandBuilder { get; set; }
        public static SQLiteDataAdapter SqLiteDataAdapter { get; set; }
        public static DataTable DataTable { get; set; }
        public static SQLiteConnection SqLiteConnection { get; set; }

        public static DataTable ExecuteSql(string appPath, string sql)
        {
            var sqliteConnection = PrepareSql(appPath, sql);
            sqliteConnection.Open();
            var sqliteCommand = new SQLiteCommand(sqliteConnection);
            var dt = new DataTable();
            try
            {
                sqliteCommand.CommandText = sql;
                var sqliteReader = sqliteCommand.ExecuteReader();
                dt.Load(sqliteReader);
                sqliteReader.Close();
            }
            catch (Exception ex)
            {
                sqliteConnection.Close();
                Log.Error("Error executed sql query: " + ex.Message);
            }
            sqliteConnection.Close();
            return dt;
        }

        public static object ExecuteSqlSqalar(string appPath, string sql)
        {
            var sqliteConnection = PrepareSql(appPath, sql);
            sqliteConnection.Open();
            var sqliteCommand = new SQLiteCommand(sqliteConnection);
            var result = new object();
            try
            {
                sqliteCommand.CommandText = sql;
                result = sqliteCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                sqliteConnection.Close();
                Log.Error("Error executed sql query: " + ex.Message);
            }
            sqliteConnection.Close();
            return result;
        }

        public static void ExecuteSqlNonQuery(string appPath, string sql)
        {
            var sqliteConnection = PrepareSql(appPath, sql);
            sqliteConnection.Open();
            var sqliteCommand = new SQLiteCommand(sqliteConnection);
            try
            {
                sqliteCommand.CommandText = sql;
                sqliteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqliteConnection.Close();
                Log.Error("Error executed sql query: " + ex.Message);
            }
            sqliteConnection.Close();
        }

        public static bool SqliteColumnExists(SQLiteCommand cmd, string table, string column)
        {
            lock (cmd.Connection)
            {
                cmd.Connection.Open();
                // make sure table exists
                cmd.CommandText = string.Format("SELECT sql FROM sqlite_master WHERE type = 'table' AND name = '{0}'", table);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bool hascol = reader.GetString(0).Contains(String.Format("\"{0}\"", column));
                    reader.Close();
                    cmd.Connection.Close();
                    return hascol;
                }
                reader.Close();
                cmd.Connection.Close();
                return false;
            }
        }

        private static SQLiteConnection PrepareSql(string appPath, string sql)
        {
            string dbApp = Path.GetDirectoryName(appPath) + "\\" + "DbDomainInfo.db";
            string connectCommand = string.Format("Data Source={0}", dbApp);
            Log.Debug(string.Format("Start execute sql query: {0}", sql));

            var sqliteConnection = new SQLiteConnection(connectCommand);
            return sqliteConnection;
        }
    }
}