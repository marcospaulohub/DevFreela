﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Core.Repositories;


namespace DevFreela.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetDetailsById(request.Id);

            if (project is null)
                return ResultViewModel<ProjectViewModel>.Error(ProjectMsgs.GetProjectNotExist());

            var model = ProjectViewModel.FromEntity(project);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}
