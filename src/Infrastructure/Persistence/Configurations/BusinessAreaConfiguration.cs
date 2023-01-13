using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BusinessAreaConfiguration : IEntityTypeConfiguration<BusinessArea>
    {
        public void Configure(EntityTypeBuilder<BusinessArea> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnName("id");

            builder.Property(b=>b.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.ToTable("business_areas");
        }
    }
}
