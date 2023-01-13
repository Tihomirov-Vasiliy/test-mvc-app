using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public static class GlobalPostgresqlEFConfiguration
    {
        public static void Apply(ModelBuilder modelBuilder)
        {
            //нужно получить все сущности, которые унаследованы от BaseEntity напрямую и 
            //для всех Id указать необходимые характеристики
            
            //получить все сущности в дальнейшем у которых есть BaseAuditableEntity
        }
    }
}
