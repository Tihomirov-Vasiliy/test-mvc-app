using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextInitializer
    {
        private ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();
        }

        public async Task TrySeedAsync()
        {
            if (!_context.Organizations.Any() &&
                !_context.Citizens.Any() &&
                !_context.BusinessAreas.Any())
            {
                Citizen ceo1 = new Citizen()
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1980, 1, 1),
                    Inn = 111111111111,
                    Snils = 22222222222,
                    RegistrationAddress = "г.Москва, ул.Пушкина, дом. Колотушкина 1"
                };
                Citizen ceo2 = new Citizen()
                {
                    FirstName = "Дарья",
                    LastName = "Петрова",
                    MiddleName = "Петровна",
                    Gender = Gender.Female,
                    BirthDate = new DateTime(1982, 2, 2),
                    Inn = 111111111134,
                    Snils = 22222222236,
                    RegistrationAddress = "г.Санкт-Петербург, ул.Ленина, дом. 2"
                };
                BusinessArea businessArea1 = new BusinessArea() { Name = "Торговля" };
                BusinessArea businessArea2 = new BusinessArea() { Name = "Промышленность" };

                Organization organization1 = new Organization()
                {
                    BusinessArea = businessArea1,
                    Inn = 1010101010,
                    Ceo = ceo1,
                    AuthorizedCapital = 1_000_000L,
                    FullName = "\'ООО\' Цветы в каждый дом",
                    ShortName = "Цветы в каждый дом",
                    Kpp = 123456789,
                    Ogrn = 1231231231234,
                };
                Organization organization2 = new Organization()
                {
                    BusinessArea = businessArea2,
                    Inn = 1010101010,
                    Ceo = ceo2,
                    AuthorizedCapital = 1_000_000L,
                    FullName = "\'ООО\' Плавильня",
                    ShortName = "Плавильня",
                    Kpp = 987654321,
                    Ogrn = 2331231231234,
                };

                _context.Organizations.Add(organization1);
                _context.Organizations.Add(organization2);
                await _context.SaveChangesAsync();
            }

        }
    }
}
