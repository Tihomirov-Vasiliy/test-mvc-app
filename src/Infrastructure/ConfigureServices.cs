using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DbConnection")));

            //services.AddScoped<IBusinessAreaRepository, BusinessAreaRepository>();
            //services.AddScoped<ICitizenRepository, CitizenRepository>();
            //services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            return services;
        }
    }
}
