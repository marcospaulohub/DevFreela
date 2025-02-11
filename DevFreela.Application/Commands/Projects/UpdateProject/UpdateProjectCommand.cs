using MediatR;
using DevFreela.Application.Models;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommand : IRequest<ResultViewModel>
    {
        public int IdProject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
