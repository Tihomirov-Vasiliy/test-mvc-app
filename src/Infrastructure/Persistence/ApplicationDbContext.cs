using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BusinessArea> BusinessAreas { get; set; }
        //public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("User ID=MvcUser;Password=password;Host=localhost;Port=5432;Database=MvcDatabase;")
                .UseSnakeCaseNamingConvention();
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            GlobalPostgresqlEFConfiguration.Apply(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
