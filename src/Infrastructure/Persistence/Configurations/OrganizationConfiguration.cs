using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(o => o.FullName)
                .HasMaxLength(200);
            //.HasColumnName("full_name");
            builder.Property(o => o.ShortName)
                .HasMaxLength(100);
                //.HasColumnName("short_name");
            builder.HasOne(o => o.BusinessArea)
                .WithMany(b => b.Organizations)
                //.HasForeignKey("business_area_id")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Property(o => o.FioCeo)
                .HasMaxLength(300);
            /*builder.HasOne(o => o.Ceo)
                 .WithMany()
                 .HasForeignKey("ceo_id");*/
            //builder.Property(o => o.AuthorizedCapital)
                //.HasColumnName("authorized_capital");
            builder.Property(o => o.Inn)
                //.HasColumnName("inn")
                .HasMaxLength(10)
                .IsFixedLength();
            builder.Property(o => o.Kpp)
                //.HasColumnName("kpp")
                .HasMaxLength(9)
                .IsFixedLength();
            builder.Property(o => o.Ogrn)
                //.HasColumnName("ogrn")
                .HasMaxLength(13)
                .IsFixedLength();
            //builder.ToTable("t_organizations");
        }
    }
}
