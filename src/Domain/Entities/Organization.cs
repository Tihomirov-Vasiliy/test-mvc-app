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
        /// <summary>
        /// Inn contains 10 digits for organizations
        /// </summary>
        public long Inn { get; set; } 
        /// <summary>
        /// Kpp contains 9 digits
        /// </summary>
        public long Kpp { get; set; }
        /// <summary>
        /// Ogrn contains 13 digits
        /// </summary>
        public long Ogrn { get; set; } 
    }
}
