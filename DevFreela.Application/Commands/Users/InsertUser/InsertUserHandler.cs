using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public InsertUserHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.Email);

            if(user != null)
            {
                return ResultViewModel<int>.Error("Usuário já existe.");
            }

            var hash = _authService.ComputeHash(request.Password);

            user = request.ToEntity(hash);

            var userId = await _repository.Add(user);

            return ResultViewModel<int>.Success(userId);
        }
    }
}
