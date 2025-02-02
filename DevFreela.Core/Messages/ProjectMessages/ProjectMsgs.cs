namespace DevFreela.Core.Messages.ProjectMessages
{
    public static class ProjectMsgs
    {
        private const string FileNameResx = "DevFreela.Core.Messages.ProjectMessages.ProjectMsgsResource";

        public static string GetTitleNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectTitleNotEmpty", FileNameResx);
        }

        public static string GetTitleMaxLength()
        {
            return BaseMsgs.GetResource("ProjectTitleMaxLength", FileNameResx);
        }

        public static string GetDescriptionNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectDescriptionNotEmpty", FileNameResx);
        }

        public static string GetIdClientNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectIdClientNotEmpty", FileNameResx);
        }

        public static string GetIdFreelancerNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectIdFreelancerNotEmpty", FileNameResx);
        }

        public static string GetTotalCostNotEmpty()
        {
            return BaseMsgs.GetResource("ProjectTotalCostNotEmpty", FileNameResx);
        }

        public static string GetTotalCostMinLength()
        {
            return BaseMsgs.GetResource("ProjectTotalCostMinLength", FileNameResx);
        }

        public static string GetProjectInvalidState()
        {
            return BaseMsgs.GetResource("ProjectInvalidState", FileNameResx);
        }

        public static string GetProjectNotExist()
        {
            return BaseMsgs.GetResource("ProjectNotExist", FileNameResx);
        }
    }
}
