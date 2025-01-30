using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Projects.StartProject
{
    public class StartProjectCommand : IRequest<ResultViewModel>
    {
        public StartProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
