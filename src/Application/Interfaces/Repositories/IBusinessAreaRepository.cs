using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IBusinessAreaRepository
    {
        Task<IEnumerable<BusinessArea>> GetAllAsync();
        Task<BusinessArea> GetByIdAsync(int id);
        Task<int> CreateAsync(BusinessArea businessArea);
        Task UpdateAsync(BusinessArea businessArea);
        Task DeleteAsync(int id);
    }
}
