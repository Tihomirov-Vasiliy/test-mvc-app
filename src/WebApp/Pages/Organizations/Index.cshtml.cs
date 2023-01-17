using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Organizations
{
    public class IndexModel : PageModel
    {
        private IOrganizationRepository _organizationRepository;
        private IBusinessAreaRepository _businessAreaRepository;

        public IList<BusinessArea> BusinessAreasWithOrganizations { get; private set; }

        [BindProperty]
        public Organization Organization { get; set; }
        [BindProperty]
        public List<SelectListItem> SelectedBusinessAreas { get; set; }
        //[BindProperty]
        //public BusinessArea ChosenBusinessArea { get; set; }

        public IndexModel(IOrganizationRepository organizationRepository, IBusinessAreaRepository businessAreaRepository)
        {
            _organizationRepository = organizationRepository;
            _businessAreaRepository = businessAreaRepository;
        }
        public async Task OnGetAsync()
        {
            IEnumerable<Organization> organizations = await _organizationRepository.GetAllAsync();
            BusinessAreasWithOrganizations = organizations.GroupBy(
                o => o.BusinessArea,
                (businessArea, organizations) =>
                new BusinessArea
                {
                    Name = (businessArea != null && businessArea.Name != null) ? businessArea.Name : "Без сферы деятельности",
                    Organizations = organizations
                }).ToList();

            var businessAreas = await _businessAreaRepository.GetAllAsync();
            SelectedBusinessAreas = businessAreas.Select(b => new SelectListItem()
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (Organization == null)
                return RedirectToPage();
            else
            {
                await _organizationRepository.UpdateAsync(Organization);
                return RedirectToPage();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _organizationRepository.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
