using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("first_name");
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("last_name");
            builder.Property(c => c.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");

        }
    }
}
