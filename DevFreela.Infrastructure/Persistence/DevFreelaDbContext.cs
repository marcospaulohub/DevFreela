using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjectMap());
            builder.ApplyConfiguration(new ProjectCommentMap());
            builder.ApplyConfiguration(new SkillMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserSkillMap());

            base.OnModelCreating(builder);
        }

    }
}
