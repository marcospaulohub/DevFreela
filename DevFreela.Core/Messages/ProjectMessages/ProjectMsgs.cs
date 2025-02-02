using System.Globalization;
using System.Resources;

namespace DevFreela.Core.Messages.ProjectMessages
{
    public static class ProjectMsgs
    {
        private const string nomeArquivoResx = "DevFreela.Core.Messages.ProjectMessages.ProjectMsgsResource";

        private static string GetResource(string key)
        {
            ResourceManager rm = new ResourceManager(nomeArquivoResx, typeof(ProjectMsgs).Assembly);

            var text = rm.GetString(key, CultureInfo.CurrentCulture);

            if (text != null)
                return text;
            else
                return "null";
        }

        public static string GetText(string key)
        {
            return GetResource(key);
        }


        public static string GetTitleNotEmpty()
        {
            return GetResource("TitleNotEmpty");
        }

        public static string GetTitleMaxLength()
        {
            return GetResource("TitleMaxLength");
        }

        public static string GetDescriptionNotEmpty()
        {
            return GetResource("DescriptionNotEmpty");
        }

        public static string GetIdClientNotEmpty()
        {
            return GetResource("IdClientNotEmpty");
        }

        public static string GetIdFreelancerNotEmpty()
        {
            return GetResource("IdFreelancerNotEmpty");
        }

        public static string GetTotalCostNotEmpty()
        {
            return GetResource("TotalCostNotEmpty");
        }

        public static string GetTotalCostMinLength()
        {
            return GetResource("TotalCostMinLength");
        }

        public static string GetProjectInvalidState()
        {
            return GetResource("ProjectInvalidState");
        }

        public static string GetProjectNotExist()
        {
            return GetResource("ProjectNotExist");
        }
    }
}
