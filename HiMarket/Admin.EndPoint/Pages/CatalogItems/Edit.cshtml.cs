using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CrudService.CatalogItems;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class EditModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly ICatalogItemEditDeleteGetListService catalogitemservice;

        public EditModel(IMapper mapper,ICatalogItemEditDeleteGetListService catalogItemservice)
        {
            this.mapper = mapper;
            this.catalogitemservice = catalogItemservice;
        }

        [BindProperty]
        public CatalogItemEditDeleteGetListServiceViewModel catalogItemViewModel { get; set; } =new CatalogItemEditDeleteGetListServiceViewModel();
        public List<String> Message { get; set; } = new List<String>();
        public void OnGet(int Id)
        {
            var model = catalogitemservice.FindById(Id);
            if(model.IsSuccess)
                catalogItemViewModel=mapper.Map<CatalogItemEditDeleteGetListServiceViewModel>(model.Data);
            Message = model.Message;
        }

        public IActionResult OnPost()
        {
            var model=mapper.Map<CatalogItemEditDeleteGetListServiceDto>(catalogItemViewModel);
            var result=catalogitemservice.Edit(model);
            Message = result.Message;
            catalogItemViewModel = mapper.Map<CatalogItemEditDeleteGetListServiceViewModel>(result.Data);

            return Page();
        }
    }
}
