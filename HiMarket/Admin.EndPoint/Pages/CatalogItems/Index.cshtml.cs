using Application.Catalogs.CatalogItems.CatalogItemServices;
using Application.Dtos;
using Application.Interfase.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.EndPoint.Pages.CatalogItems
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogItemService catalogItemService;

        public IndexModel(ICatalogItemService catalogItemService)
        {
            this.catalogItemService = catalogItemService;
        }
       
        public PaginatedItemDto<CatalogItemListItemDto> CatalogItems { get; set; }
        public void OnGet(int page=1,int pageSize=100)
        {
            CatalogItems = catalogItemService.GetCatalogList(page, pageSize);
        }
    }
}
