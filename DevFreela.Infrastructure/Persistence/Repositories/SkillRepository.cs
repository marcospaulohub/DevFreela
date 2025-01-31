using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;

        public SkillRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Skill skill)
        {
            await _context.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public Task<List<Skill>> GetAll()
        {
            var skills = _context.Skills.ToListAsync();

            return skills;
        }
    }
}
