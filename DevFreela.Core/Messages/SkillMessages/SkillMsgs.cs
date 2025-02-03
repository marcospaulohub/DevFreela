namespace DevFreela.Core.Messages.SkillMessages
{
    public static class SkillMsgs 
    {
        private const string fileNameResx = "DevFreela.Core.Messages.SkillMessages.SkillMsgsResource";

        public static string GetDescriptionNotEmpty()
        {
            return BaseMsgs.GetResource("SkillDescriptionNotEmpty", fileNameResx);
        }

        public static string GetDescriptionMaxLength()
        {
            return BaseMsgs.GetResource("SkillDescriptionMaxLength", fileNameResx);
        }
    }
}
