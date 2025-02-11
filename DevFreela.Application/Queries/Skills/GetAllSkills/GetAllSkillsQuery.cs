using DevFreela.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<ResultViewModel<List<SkillItemViewModel>>>
    {
    }
}
