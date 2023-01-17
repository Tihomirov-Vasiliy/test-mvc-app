using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    /*
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.Property(c => c.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            builder.Property(c => c.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            builder.Property(c => c.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");
            builder.Property(c => c.BirthDate)
                .HasColumnName("birth_date");
            builder.Property(c => c.Gender)
                .HasColumnName("gender")
                .HasConversion<string>()
                .HasMaxLength(10);
            builder.Property(c => c.RegistrationAddress)
                .HasMaxLength(200)
                .HasColumnName("registration_address");
            builder.Property(c => c.Inn)
                .HasColumnName("inn");
            builder.Property(c => c.Snils)
                .HasColumnName("snils");

            builder.ToTable("t_citizens");
        }
    }*/
}
