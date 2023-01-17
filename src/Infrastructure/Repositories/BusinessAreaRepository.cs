using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Persistence;
using Infrastructure.Validators;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BusinessAreaRepository : IBusinessAreaRepository
    {
        private ApplicationDbContext _context;

        public BusinessAreaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BusinessArea>> GetAllAsync()
        {
            return await _context.BusinessAreas
                .AsNoTracking()
                .OrderBy(b => b.Id)
                .ToListAsync();
        }

        public async Task<BusinessArea> GetByIdAsync(int id)
        {
            ValueValidator.IdValueGreaterThanZero(id);

            return await _context.BusinessAreas.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> CreateAsync(BusinessArea businessArea)
        {
            if (businessArea == null)
                throw new ArgumentNullException("Сфера деятельности не может быть пустой. Создание отменено.");

            if (_context.BusinessAreas.Any(b => b.Name == businessArea.Name))
                throw new QniqueValueException($"Сфера деятельности с таким именем существует, попробуйте другое имя");

            _context.BusinessAreas.Add(businessArea);
            await _context.SaveChangesAsync();

            return businessArea.Id;
        }
        public async Task UpdateAsync(BusinessArea businessArea)
        {
            if (businessArea == null)
                throw new ArgumentNullException("Сфера деятельности не может быть пустой. Обновление отменено.");

            ValueValidator.IdValueGreaterThanZero(businessArea.Id);

            if (!_context.BusinessAreas.Any(b => b.Id == businessArea.Id))
                throw new NotFoundException($"Сфера деятельности с Id: {businessArea.Id} не найдена. Обновление отменено.");

            _context.BusinessAreas.Update(businessArea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ValueValidator.IdValueGreaterThanZero(id);

            BusinessArea businessArea = await GetByIdAsync(id);

            if (businessArea == null)
                throw new NotFoundException($"Сфера деятельности с Id: {id} не найдена. Удаление отменено.");

            _context.BusinessAreas.Remove(businessArea);
            await _context.SaveChangesAsync();
        }
    }
}
