using System.IO;

namespace Acme_Corporation_Core.App_Code.Helpers
{
    public static class FileHelper
    {
        public static string LoadFileContents(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
