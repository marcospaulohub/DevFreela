using DevFreela.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {

    }
}
