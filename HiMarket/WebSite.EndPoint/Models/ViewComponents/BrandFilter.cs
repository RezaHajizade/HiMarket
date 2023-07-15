using Application.Catalogs.CatalogItems.CatalogItemServices;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Models.ViewComponents
{
    public class BrandFilter : ViewComponent
    {
        private readonly ICatalogItemService catalogItemService;
        public BrandFilter(ICatalogItemService catalogItemService)
        {
            this.catalogItemService = catalogItemService;
        }

        public IViewComponentResult Invoke()
        {
            var brands = catalogItemService.GetBrand();
            return View(viewName: "BrandFilter", model: brands);
        }

    }
}
