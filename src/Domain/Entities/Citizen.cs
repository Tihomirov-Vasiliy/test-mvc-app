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
        public long Inn { get; set; } //12 digits
        public long Snils { get; set; } //11 digits
    }
}
