using System.Configuration;

namespace Acme_Corporation_Core.App_Code.Helpers
{
    public static class AppSettingsHelper
    {
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
}