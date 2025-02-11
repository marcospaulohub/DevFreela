﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.Skills.InsertSkill
{
    public class InsertSkillHandler : IRequestHandler<InsertSkillCommand, ResultViewModel<int>>
    {
        public readonly ISkillRepository _repository;

        public InsertSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = request.ToEntity();
            
            await _repository.Add(skill);

            return ResultViewModel<int>.Success(skill.Id);
        }
    }
}
