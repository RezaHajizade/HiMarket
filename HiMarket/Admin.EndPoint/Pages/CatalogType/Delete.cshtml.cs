using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CatalogTypes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;

        public DeleteModel(ICatalogTypeService catalogTypeService, IMapper mapper)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
        }
        [BindProperty]
        public CatalogTypeViewModel CatalogTypeViewModel { get; set; } = new CatalogTypeViewModel();
        public List<String> Message { get; set; } = new List<String>();

        public void OnGet(int Id)
        {
            var model = catalogTypeService.FindById(Id);
            if (model.IsSuccess)
                CatalogTypeViewModel = mapper.Map<CatalogTypeViewModel>(model.Data);
            Message = model.Message;
        }

        public IActionResult OnPost()
        {
            var result = catalogTypeService.Remove(CatalogTypeViewModel.Id);
            Message = result.Message;
            if (result.IsSuccess)
            {
                return RedirectToPage("index");

            }
            return Page();

        }

    }
}
