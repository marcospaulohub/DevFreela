using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.Users.Login
{
    public class LoginQuery : IRequest<ResultViewModel<LoginViewModel>>
    {
        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
