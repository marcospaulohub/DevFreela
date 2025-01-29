using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                  .HasColumnType("varchar(200)")
                  .IsRequired();

            builder.Property(u => u.Email)
                  .HasColumnType("varchar(200)")
                  .IsRequired();

            builder.Property(u => u.BirthDate)
                   .HasColumnType("datetime2(7)");

            builder.Property(u => u.Active)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.HasMany(u => u.Skills)
                   .WithOne(u => u.User)
                   .HasForeignKey(u => u.IdUser)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
