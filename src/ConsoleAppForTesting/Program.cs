using Domain.Entities;

namespace ConsoleAppForTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessArea businessArea1 = new BusinessArea() { Name = "Торговля" };
            BusinessArea businessArea2 = new BusinessArea() { Name = "Промышленность" };

            Organization organization1 = new Organization()
            {
                BusinessArea = businessArea1,
                Inn = 1010101010,
                //Ceo = new Citizen(),
                FioCeo = "Иванов Иван Иванович",
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
                FioCeo = "Петров Петр Петрович",
                AuthorizedCapital = 1_000_000L,
                FullName = "\'ООО\' Плавильня",
                ShortName = "Плавильня",
                Kpp = 987654321,
                Ogrn = 2331231231234,
            };
            Organization organization3 = new Organization()
            {
                BusinessArea = null,
                Inn = 1010101010,
                FioCeo = "Бибабоба бобович",
                AuthorizedCapital = 1_000_000L,
                FullName = "\'ООО\' Плавильня",
                ShortName = "Плавильня",
                Kpp = 987654321,
                Ogrn = 2331231231234,
            };

            List<Organization> organizations = new List<Organization>() { organization1, organization2, organization3 };

            Console.WriteLine("############# GROUP BY #############");
            var groupBy = organizations
                .GroupBy(o => o.BusinessArea, (businessArea, organizations) =>
                new
                {
                    Key = businessArea != null ? businessArea.Name : "Без сферы деятельности",
                    Organizations = organizations
                });
            foreach (var item in groupBy)
            {
                Console.WriteLine(item.Key);
                foreach (var organization in item.Organizations)
                {
                    Console.WriteLine(organization.FullName);
                }
            }

            Console.WriteLine();
        }
    }
}