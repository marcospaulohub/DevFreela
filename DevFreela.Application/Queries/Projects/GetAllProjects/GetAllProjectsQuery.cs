using System.Collections.Generic;
using MediatR;
using DevFreela.Application.Models;

namespace DevFreela.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {

    }
}
