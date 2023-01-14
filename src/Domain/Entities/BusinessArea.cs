using Domain.Common;

namespace Domain.Entities
{
    public class BusinessArea : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Organization> Organizations { get; set; }
    }
}
