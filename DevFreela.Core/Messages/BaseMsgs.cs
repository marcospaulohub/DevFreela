using System.Globalization;
using System.Resources;

namespace DevFreela.Core.Messages
{
    public static class BaseMsgs 
    {
        public static string GetResource(string key, string FileNameResx)
        {
            var rm = new ResourceManager(FileNameResx, typeof(BaseMsgs).Assembly);

            var text = rm.GetString(key, CultureInfo.CurrentCulture);

            if (text != null)
                return text;
            else
                return "null";
        }
    }
}
