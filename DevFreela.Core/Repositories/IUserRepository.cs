using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByEmail(string email);
        Task<int> Add(User user);
        Task Update(User user);
        Task AddSkill(List<UserSkill> userSkills);
        Task<User?> Login(string email, string hash);
    }
}
