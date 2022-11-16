using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CatalogTypes;
using Application.Catalogs.CrudService.CatalogItems;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogItemEditDeleteGetListService catalogservice;
        private readonly IMapper mapper;

        public DeleteModel(ICatalogItemEditDeleteGetListService catalogservice,IMapper mapper)
        {
            this.catalogservice = catalogservice;
            this.mapper = mapper;
        }
        [BindProperty]
        public CatalogItemEditDeleteGetListServiceViewModel catalogItemViewModel { get; set; } = new CatalogItemEditDeleteGetListServiceViewModel();
        public List<String> Message { get; set; } = new List<String>();
        public void OnGet(int id)
        {
            var model=catalogservice.FindById(id);
            if(model.IsSuccess)
                catalogItemViewModel=mapper.Map<CatalogItemEditDeleteGetListServiceViewModel>(model.Data);
            Message = model.Message;
        }

        public IActionResult OnPost()
        {
            var result = catalogservice.Delete(catalogItemViewModel.Id);
            Message = result.Message;
            if (result.IsSuccess)
            {
                return RedirectToPage("index");

            }
            return Page();

        }
    }
}
