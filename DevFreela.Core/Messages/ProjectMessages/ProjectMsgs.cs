namespace DevFreela.Core.Messages.ProjectMessages
{
    public static class ProjectMsgs
    {
        private const string fileNameResx = "DevFreela.Core.Messages.ProjectMessages.ProjectMsgsResource";

        public static string GetTitleNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectTitleNotEmpty", fileNameResx);
        }

        public static string GetTitleMaxLength()
        {
            return BaseMsgs.GetResource("ProjectTitleMaxLength", fileNameResx);
        }

        public static string GetDescriptionNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectDescriptionNotEmpty", fileNameResx);
        }

        public static string GetIdClientNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectIdClientNotEmpty", fileNameResx);
        }

        public static string GetIdFreelancerNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectIdFreelancerNotEmpty", fileNameResx);
        }

        public static string GetTotalCostNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectTotalCostNotEmpty", fileNameResx);
        }

        public static string GetTotalCostMinLength()
        {
            return BaseMsgs.GetResource("ProjectTotalCostMinLength", fileNameResx);
        }

        public static string GetProjectInvalidState()
        {
            return BaseMsgs.GetResource("ProjectInvalidState", fileNameResx);
        }

        public static string GetProjectNotExist()
        {
            return BaseMsgs.GetResource("ProjectNotExist", fileNameResx);
        }

        public static string GetIdClientInvalid()
        {
            return BaseMsgs.GetResource("ProjectIdClientInvalid", fileNameResx);
        }
        public static string GetIdFreelancerInvalid()
        {
            return BaseMsgs.GetResource("ProjectIdFreelancerInvalid", fileNameResx);
            
        }
    }
}
