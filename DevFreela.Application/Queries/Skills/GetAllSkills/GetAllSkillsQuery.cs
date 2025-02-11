using System.Collections.Generic;
using MediatR;
using DevFreela.Application.Models;

namespace DevFreela.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<ResultViewModel<List<SkillItemViewModel>>>
    {
    }
}
