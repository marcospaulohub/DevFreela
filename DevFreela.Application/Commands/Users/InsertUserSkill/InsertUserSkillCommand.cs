using MediatR;
using DevFreela.Application.Models;

namespace DevFreela.Application.Commands.Users.InsertUserSkill
{
    public class InsertUserSkillCommand : IRequest<ResultViewModel>
    {
        public int[] SkillIds { get; set; }
        public int Id { get; set; }
    }
}
