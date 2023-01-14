using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Persistence.Configurations
{
    public static class GlobalPostgresqlEFConfiguration
    {
        public static void Apply(ModelBuilder modelBuilder)
        {
            //Смена регистра и обозначение для типа генерации значения для первичных ключей
            //Id -> id INT GENERATED ALWAYS AS IDENTITY
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
            {
                var idProperty = entityType.GetProperty("Id");
                idProperty.SetColumnName("id");
                idProperty.SetValueGenerationStrategy(NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
            }
        }
    }
}
