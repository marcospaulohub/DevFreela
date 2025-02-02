namespace DevFreela.Core.Messages.UserMessages
{
    public class UserMsgs
    {
        private const string FileNameResx = "DevFreela.Core.Messages.UserMessages.UserMsgsResource";

        public static string GetFullnameNotEmpty()
        {
            return BaseMsgs.GetResource("UserFullNameNotEmpty", FileNameResx);
        }
        public static string GetFullnameMaxLength()
        {
            return BaseMsgs.GetResource("UserFullnameMaxLength", FileNameResx);
        }
        public static string GetEmailNotEmpty()
        {
            return BaseMsgs.GetResource("UserEmailNotEmpty", FileNameResx);
        }
        public static string GetEmailMaxLength()
        {
            return BaseMsgs.GetResource("UserEmailMaxLength", FileNameResx);
        }
        public static string GetEmailInvalid()
        {
            return BaseMsgs.GetResource("UserEmailInvalid", FileNameResx);
        }
        public static string GetBirthDateNotEmpty()
        {
            return BaseMsgs.GetResource("UserBirthDateNotEmpty", FileNameResx);
        }
        public static string GetBirtDateMinAge()
        {
            return BaseMsgs.GetResource("UserBirtDateMinAge", FileNameResx);
        }
    }
}
