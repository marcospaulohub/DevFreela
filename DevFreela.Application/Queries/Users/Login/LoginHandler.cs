using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Messages.UserMessages;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;

namespace DevFreela.Application.Queries.Users.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, ResultViewModel<LoginViewModel>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public LoginHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel<LoginViewModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var hash = _authService.ComputeHash(request.Password);

            var user = await _repository.Login(request.Email, hash);

            if (user is null)
            {
                return ResultViewModel<LoginViewModel>.Error(UserMsgs.GetUserNotExist());
            }

            var token = _authService.GenerateToken(user.Email, user.Role);

            var model = LoginViewModel.FromEntity(token);

            return ResultViewModel<LoginViewModel>.Success(model);
        }
    }
}
