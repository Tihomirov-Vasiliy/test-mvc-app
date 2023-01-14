using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Citizen : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string RegistrationAddress { get; set; }
        /// <summary>
        /// Inn contains 12 digits for citizen
        /// </summary>
        public long Inn { get; set; }
        /// <summary>
        /// Snils contains 11 digits
        /// </summary>
        public long Snils { get; set; }
    }
}
