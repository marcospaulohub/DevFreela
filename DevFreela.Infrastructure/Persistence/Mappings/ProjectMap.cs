using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Mappings
{
    internal class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(p => p.Description)
                   .HasColumnType("varchar(max)")
                   .IsRequired();

            builder.Property(p => p.IdClient)
                   .IsRequired();

            builder.Property(p => p.IdFreelancer)
                   .IsRequired();

            builder.Property(p => p.TotalCost)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();


            builder.HasOne(p => p.Freelancer)
                   .WithMany(f => f.FrelanceProjects)
                   .HasForeignKey(p => p.IdFreelancer)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Client)
                   .WithMany(c => c.OwnedProjects)
                   .HasForeignKey(p => p.IdClient)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
