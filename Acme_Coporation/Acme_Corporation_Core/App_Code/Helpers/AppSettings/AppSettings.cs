namespace Acme_Corporation_Core.App_Code.Helpers
{
    public static class AppSettings
    {
        public static string umbracoDbDSN => AppSettingsHelper.GetConnectionString("umbracoDbDSN");
    }
}