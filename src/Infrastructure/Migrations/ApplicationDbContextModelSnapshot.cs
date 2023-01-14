﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.BusinessArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("t_business_areas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Citizen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("gender");

                    b.Property<long>("Inn")
                        .HasColumnType("bigint")
                        .HasColumnName("inn");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("middle_name");

                    b.Property<string>("RegistrationAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("registration_address");

                    b.Property<long>("Snils")
                        .HasColumnType("bigint")
                        .HasColumnName("snils");

                    b.HasKey("Id");

                    b.ToTable("t_citizens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<long>("AuthorizedCapital")
                        .HasColumnType("bigint")
                        .HasColumnName("authorized_capital");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("full_name");

                    b.Property<long>("Inn")
                        .HasMaxLength(10)
                        .HasColumnType("bigint")
                        .HasColumnName("inn")
                        .IsFixedLength();

                    b.Property<long>("Kpp")
                        .HasMaxLength(9)
                        .HasColumnType("bigint")
                        .HasColumnName("kpp")
                        .IsFixedLength();

                    b.Property<long>("Ogrn")
                        .HasMaxLength(13)
                        .HasColumnType("bigint")
                        .HasColumnName("ogrn")
                        .IsFixedLength();

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("short_name");

                    b.Property<int>("business_area_id")
                        .HasColumnType("integer");

                    b.Property<int>("ceo_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("business_area_id");

                    b.HasIndex("ceo_id");

                    b.ToTable("t_organizations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Organization", b =>
                {
                    b.HasOne("Domain.Entities.BusinessArea", "BusinessArea")
                        .WithMany("Organizations")
                        .HasForeignKey("business_area_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Citizen", "Ceo")
                        .WithMany()
                        .HasForeignKey("ceo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessArea");

                    b.Navigation("Ceo");
                });

            modelBuilder.Entity("Domain.Entities.BusinessArea", b =>
                {
                    b.Navigation("Organizations");
                });
#pragma warning restore 612, 618
        }
    }
}
