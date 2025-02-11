using DevFreela.Application.Models;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public UpdateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.IdProject);

            if (project is null)
                return ResultViewModel.Error(ProjectMsgs.GetProjectNotExist());

            project.Update(request.Title, request.Description, request.TotalCost);

            await _repository.Update(project);

            return ResultViewModel.Success();
        }
    }
}
