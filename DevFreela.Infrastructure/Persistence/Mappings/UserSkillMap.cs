using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Mappings
{
    internal class UserSkillMap : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.ToTable("UserSkills");

            builder.HasKey(us => us.Id);

            builder.Property(us => us.IdUser)
                   .IsRequired();

            builder.Property(us => us.IdSkill)
                   .IsRequired();

            builder.HasOne(us => us.Skill)
                   .WithMany(us => us.UserSkills)
                   .HasForeignKey(us => us.IdSkill)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

