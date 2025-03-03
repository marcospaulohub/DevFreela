using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;

        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .ThenInclude(u => u.Skill)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }
        public async Task<User?> GetByEmail(string email)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .ThenInclude(u => u.Skill)
                .SingleOrDefaultAsync(u => u.Email == email);

            return user;
        }
        public async Task Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
        public async Task<User?> Login(string email, string hash)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == hash);

            return user;
        }
        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
        public async Task AddSkill(List<UserSkill> userSkills)
        {
            await _context.UserSkills.AddRangeAsync(userSkills);
            await _context.SaveChangesAsync();
        }
    }
}
