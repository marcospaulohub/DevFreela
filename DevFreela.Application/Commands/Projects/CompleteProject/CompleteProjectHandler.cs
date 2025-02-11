using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.Projects.CompleteProject
{
    internal class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public CompleteProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            if (project is null)
                return ResultViewModel.Error(ProjectMsgs.GetProjectNotExist());

            project.Complete();

            await _repository.Update(project);

            return ResultViewModel.Success();
        }
    }
}
