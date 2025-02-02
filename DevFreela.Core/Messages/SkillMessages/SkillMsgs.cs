namespace DevFreela.Core.Messages.SkillMessages
{
    public static class SkillMsgs 
    {
        private const string FileNameResx = "DevFreela.Core.Messages.SkillMessages.SkillMsgsResource";

        public static string GetDescriptionNotEmpty()
        {
            return BaseMsgs.GetResource("SkillDescriptionNotEmpty", FileNameResx);
        }

        public static string GetDescriptionMaxLength()
        {
            return BaseMsgs.GetResource("SkillDescriptionMaxLength", FileNameResx);
        }
    }
}
