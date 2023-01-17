using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DbConnection"))
                .UseSnakeCaseNamingConvention()
                .LogTo(Console.WriteLine));

            services.AddScoped<IBusinessAreaRepository, BusinessAreaRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<ApplicationDbContextInitializer>();

            return services;
        }
    }
}
