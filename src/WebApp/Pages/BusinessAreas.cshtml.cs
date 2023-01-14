using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class BusinessAreasModel : PageModel
    {
        private IBusinessAreaRepository _repository;
        public IEnumerable<BusinessArea> BusinessAreas { get; private set; }
        public BusinessAreasModel(IBusinessAreaRepository businessAreaRepository)
        {
            _repository = businessAreaRepository;
        }
        public async Task OnGet()
        {
            BusinessAreas = await _repository.GetAllAsync();
        }
    }
}
