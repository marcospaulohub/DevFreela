namespace DevFreela.Application.Models
{
    public class LoginViewModel(string token)
    {
        public string Token { get; set; } = token;

        public static LoginViewModel FromEntity(string token)
            => new(token);
    }
}
