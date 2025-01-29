using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Mappings
{
    internal class ProjectCommentMap : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder.ToTable("ProjectComments");

            builder.HasKey(pc => pc.Id);

            builder.HasOne(pc => pc.Project)
                   .WithMany(pc => pc.Comments)
                   .HasForeignKey(pc => pc.IdProject)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
