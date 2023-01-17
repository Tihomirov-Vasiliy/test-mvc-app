using Domain.Common;

namespace Domain.Entities
{
    public class BusinessArea : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
    }
}
