using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAllAsync();
        Task<Organization> GetByIdAsync(int id);
        Task<int> CreateAsync(Organization organization);
        Task UpdateAsync(Organization organization);
        Task DeleteAsync(int id);
    }
}
