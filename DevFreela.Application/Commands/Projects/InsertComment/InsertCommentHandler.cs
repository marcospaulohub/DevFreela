﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.Projects.InsertComment
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public InsertCommentHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(request.IdProject);

            if (!exists)
                return ResultViewModel.Error(ProjectMsgs.GetProjectNotExist());

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _repository.AddComment(comment);

            return ResultViewModel.Success();
        }
    }
}
