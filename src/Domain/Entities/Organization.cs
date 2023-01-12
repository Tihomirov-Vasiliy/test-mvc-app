using Domain.Common;

namespace Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public BusinessArea BusinessArea { get; set; }
        public Citizen Ceo { get; set; }
        public string AuthorizedCapital { get; set; }
        public long Inn { get; set; }
        public long Kpp { get; set; }
        public long Ogrn { get; set; }
    }
}
