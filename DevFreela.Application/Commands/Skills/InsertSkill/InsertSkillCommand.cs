﻿using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Entities;

namespace DevFreela.Application.Commands.Skills.InsertSkill
{
    public class InsertSkillCommand : IRequest<ResultViewModel<int>>
    {
        public InsertSkillCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
        public Skill ToEntity()
            => new(Description);
    }
}
