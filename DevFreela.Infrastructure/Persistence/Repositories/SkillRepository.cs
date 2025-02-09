using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

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
