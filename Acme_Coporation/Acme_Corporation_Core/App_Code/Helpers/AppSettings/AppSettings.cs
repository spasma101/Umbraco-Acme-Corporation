namespace Acme_Corporation_Core.App_Code.Helpers
{
    public static class AppSettings
    {
        public static string umbracoDbDSN => AppSettingsHelper.GetConnectionString("umbracoDbDSN");
        public static bool IsTest => AppSettingsHelper.GetSetting("IsTest").ToBool();
        public static string TestingEmailRecipent => AppSettingsHelper.GetSetting("TestingEmailRecipent");
        public static string ProductionEmailRecipient => AppSettingsHelper.GetSetting("ProductionEmailRecipient");
    }
}