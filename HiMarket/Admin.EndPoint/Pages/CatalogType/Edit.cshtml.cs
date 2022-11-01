using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CatalogTypes;
using AutoMapper;
using Domain.Catalogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class EditModel : PageModel
    {
        private readonly ICatalogTypeService _catalogTypeService;
        private readonly IMapper _mapper;

        public EditModel(ICatalogTypeService catalogTypeService,IMapper mapper)
        {
            _catalogTypeService = catalogTypeService;
            _mapper = mapper;
        }

        [BindProperty]
        public CatalogTypeViewModel catalogType { get; set; } = new CatalogTypeViewModel();
       public List<String> Message { get; set; }=new List<String>();
        public void OnGet(int Id)
        {
            var model=_catalogTypeService.FindById(Id);
            if (model.IsSuccess)
                catalogType = _mapper.Map<CatalogTypeViewModel>(model.Data);
            Message=model.Message;
        }

        public IActionResult OnPost()
        {
            var model = _mapper.Map<CatalogTypeDto>(catalogType);
            var result=_catalogTypeService.Edit(model);
            Message=result.Message;
            catalogType = _mapper.Map<CatalogTypeViewModel>(result.Data);
            return Page();
        }
    }
}
