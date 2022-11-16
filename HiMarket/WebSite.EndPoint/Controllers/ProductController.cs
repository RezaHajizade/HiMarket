using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;

        public ProductController(IGetCatalogItemPLPService getCatalogItemPLPService)
        {
            this.getCatalogItemPLPService = getCatalogItemPLPService;
        }
        public IActionResult Index(int page=1,int pageSize=20)
        {
            var data = getCatalogItemPLPService.Execute(page, pageSize);

            return View(data);
        }
    }
}
