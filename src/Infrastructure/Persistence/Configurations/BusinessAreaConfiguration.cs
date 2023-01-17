using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BusinessAreaConfiguration : IEntityTypeConfiguration<BusinessArea>
    {
        public void Configure(EntityTypeBuilder<BusinessArea> builder)
        {
            builder.Property(b => b.Name)
                .HasMaxLength(100);
               // .HasColumnName("name");

            //builder.ToTable("t_business_areas");
        }
    }
}
