using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.Projects.InsertProject
{
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly IMediator _mediator;
        private readonly IProjectRepository _repository;

        public InsertProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public InsertProjectHandler(IMediator mediator, IProjectRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            var projectId = await _repository.Add(project);

            //var projectCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost);
            //await _mediator.Publish(projectCreated);

            return ResultViewModel<int>.Success(projectId);
        }
    }
}
