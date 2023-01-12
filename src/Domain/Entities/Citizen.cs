using Domain.Common;

namespace Domain.Entities
{
    public class Citizen : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string RegistrationAddress { get; set; }
        public long Inn { get; set; }
        public long Snils { get; set; }
    }
}
