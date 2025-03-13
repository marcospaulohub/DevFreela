namespace DevFreela.Core.Messages.UserMessages
{
    public class UserMsgs
    {
        private const string fileNameResx = "DevFreela.Core.Messages.UserMessages.UserMsgsResource";

        public static string GetFullnameNotEmpty()
        {
            return BaseMsgs.GetResource("UserFullNameNotEmpty", fileNameResx);
        }
        public static string GetFullnameMaxLength()
        {
            return BaseMsgs.GetResource("UserFullnameMaxLength", fileNameResx);
        }
        public static string GetEmailNotEmpty()
        {
            return BaseMsgs.GetResource("UserEmailNotEmpty", fileNameResx);
        }
        public static string GetEmailMaxLength()
        {
            return BaseMsgs.GetResource("UserEmailMaxLength", fileNameResx);
        }
        public static string GetEmailInvalid()
        {
            return BaseMsgs.GetResource("UserEmailInvalid", fileNameResx);
        }
        public static string GetBirthDateNotEmpty()
        {
            return BaseMsgs.GetResource("UserBirthDateNotEmpty", fileNameResx);
        }
        public static string GetBirtDateMinAge()
        {
            return BaseMsgs.GetResource("UserBirtDateMinAge", fileNameResx);
        }
        public static string GetUserNotExist()
        {
            return BaseMsgs.GetResource("UserNotExist", fileNameResx);
        }
        public static string GetUserExist()
        {
            return BaseMsgs.GetResource("UserExist", fileNameResx);
        }
        public static string GetPasswordNotEmpty()
        {
            return BaseMsgs.GetResource("UserPasswordNotEmpty", fileNameResx);
        }
        public static string GetPasswordMaxLength()
        {
            return BaseMsgs.GetResource("UserPasswordMaxLength", fileNameResx);
        }
        public static string GetRoleNotEmpty()
        {
            return BaseMsgs.GetResource("UserRoleNotEmpty", fileNameResx);
        }
        public static string GetRoleMaxLength()
        {
            return BaseMsgs.GetResource("UserRoleMaxLength", fileNameResx);
        }

        public static string GetUserRequestPasswordRecoveryError()
        {
            return BaseMsgs.GetResource("UserRequestPasswordRecoveryError", fileNameResx);
        }

        public static string GetUserRequestPasswordRecoverySubject()
        {
            return BaseMsgs.GetResource("UserRequestPasswordRecoverySubject", fileNameResx);
        }

        public static string GetUserRequestPasswordRecoveryMessage()
        {
            return BaseMsgs.GetResource("UserRequestPasswordRecoveryMessage", fileNameResx);
        }

        public static string GetUserValidateRecoveryCodeError()
        {
            return BaseMsgs.GetResource("UserValidateRecoveryCodeError", fileNameResx);
        }

        public static string GetUserChangePasswordError()
        {
            return BaseMsgs.GetResource("UserChangePasswordError", fileNameResx);
        }
    }
}
