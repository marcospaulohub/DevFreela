using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.Users.InsertUserSkill
{
    public class InsertUserSkillHandler : IRequestHandler<InsertUserSkillCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;

        public InsertUserSkillHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertUserSkillCommand request, CancellationToken cancellationToken)
        {
            var userSkills = request.SkillIds.Select(s => new UserSkill(request.Id, s)).ToList();

            await _repository.AddSkill(userSkills);

            return ResultViewModel.Success();
        }
    }
}
