using Domain.Common;

namespace Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public BusinessArea BusinessArea { get; set; }
        public Citizen Ceo { get; set; }
        public long AuthorizedCapital { get; set; }
        public long Inn { get; set; } //10 digits
        public long Kpp { get; set; } //9 digits
        public long Ogrn { get; set; } //13 digits
    }
}
