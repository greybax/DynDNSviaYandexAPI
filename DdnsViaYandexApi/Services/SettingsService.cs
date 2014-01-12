namespace Core.Services
{
    public static class SettingsService
    {
        public static string GetSetting(string key, string appPath)
        {
            var query = "SELECT Value FROM Settings where Key = '" + key + "'";
            return DatabaseService.ExecuteSqlSqalar(appPath, query).ToString();
        }

        public static void SetSetting(string key, string value, string appPath)
        {
            var query = "update Settings set Value = '" + value + "' where Key = '" + key + "'";
            DatabaseService.ExecuteSqlNonQuery(appPath, query);
        }
    }
}