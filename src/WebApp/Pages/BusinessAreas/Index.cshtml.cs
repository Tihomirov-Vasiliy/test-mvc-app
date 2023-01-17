using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.BusinessAreas
{
    public class IndexModel : PageModel
    {
        private readonly IBusinessAreaRepository _businessAreaRepository;

        [BindProperty]
        public BusinessArea BusinessArea { get; set; }
        public IEnumerable<BusinessArea> BusinessAreas { get; private set; }
        public IndexModel(IBusinessAreaRepository businessAreaRepository)
        {
            _businessAreaRepository = businessAreaRepository;
        }

        public async Task OnGetAsync()
        {
            BusinessAreas = await _businessAreaRepository.GetAllAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (BusinessArea == null)
                return RedirectToPage();
            else
            {
                int businessAreaId = await _businessAreaRepository.CreateAsync(BusinessArea);
                return RedirectToPage();
            }
        }
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (BusinessArea == null)
                return RedirectToPage();
            else
            {
                await _businessAreaRepository.UpdateAsync(BusinessArea);
                return RedirectToPage();
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _businessAreaRepository.DeleteAsync(id);
            return RedirectToPage();
        }
        public async Task<PartialViewResult> OnGetBusinessAreaUpdateModalAsync(int id)
        {
            BusinessArea businessArea = await _businessAreaRepository.GetByIdAsync(id);
            return Partial("_CreateUpdateDeletePopup", businessArea);
        }
    }
}
