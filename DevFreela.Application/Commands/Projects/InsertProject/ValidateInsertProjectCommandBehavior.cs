using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DevFreela.Application.Models;
using DevFreela.Core.Messages.ProjectMessages;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.Projects.InsertProject
{
    public class ValidateInsertProjectCommandBehavior :
        IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>
    {

        private readonly DevFreelaDbContext _context;

        public ValidateInsertProjectCommandBehavior(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var clientExists = _context.Users.Any(u => u.Id == request.IdClient);
            var freelancerExists = _context.Users.Any(u => u.Id == request.IdFreelancer);

            if (!clientExists)
                return ResultViewModel<int>.Error(ProjectMsgs.GetIdClientInvalid());

            if (!freelancerExists)
                return ResultViewModel<int>.Error(ProjectMsgs.GetIdFreelancerInvalid());

            return await next();
        }
    }
}
