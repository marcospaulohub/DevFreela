using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.Models;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.Projects.StartProject
{
    public class StartProjectHandler : IRequestHandler<StartProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public StartProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            if (project is null)
                return ResultViewModel.Error(ProjectMsgs.GetProjectNotExist());

            project.Start();

            await _repository.Update(project);

            return ResultViewModel.Success();
        }
    }
}
