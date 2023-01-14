using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class OrganizationsModel : PageModel
    {
        private IOrganizationRepository _repository;
        // public IEnumerable<Organization> Organizations { get; private set; }
        public IEnumerable<IGrouping<BusinessArea, Organization>>  BusinessAreasWithOrganizations { get; private set; }
        public OrganizationsModel(IOrganizationRepository organizationRepository)
        {
            _repository = organizationRepository;
        }
        public async Task OnGetAsync()
        {
            var organizations = await _repository.GetAllAsync();
            BusinessAreasWithOrganizations = organizations.GroupBy(o=>o.BusinessArea).ToList();
        }
    }
}
