using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Persistence;
using Infrastructure.Validators;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private ApplicationDbContext _context;

        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            return await _context.Organizations
                .Include(o => o.BusinessArea)
                .Include(o => o.Ceo)
                .OrderBy(o => o.Id) 
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Organization> GetByIdAsync(int id)
        {
            ValueValidator.IdValueGreaterThanZero(id);

            return await _context.Organizations
                .Include(o => o.BusinessArea)
                .Include(o => o.Ceo)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<int> CreateAsync(Organization organization)
        {
            if (organization == null)
                throw new ArgumentNullException("Организация не может быть пустой. Создание отменено.");

            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return organization.Id;
        }
        public async Task UpdateAsync(Organization organization)
        {
            if (organization == null)
                throw new ArgumentNullException("Организация не может быть пустой. Обновление отменено.");

            ValueValidator.IdValueGreaterThanZero(organization.Id);

            Organization currentOrganization = await GetByIdAsync(organization.Id);
            if (currentOrganization == null)
                throw new NotFoundException($"Организация с Id: {organization.Id} не найдена. Обновление отменено.");

            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ValueValidator.IdValueGreaterThanZero(id);

            Organization organization = await GetByIdAsync(id);

            if (organization == null)
                throw new NotFoundException($"Организация с Id: {id} не найдена. Удаление отменено.");

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
        }
    }
}
