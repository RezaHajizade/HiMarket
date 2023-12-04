using Application.Catalogs.CatalogItems.GetCatalogItemPDP;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;
        private readonly IGetCatalogItemPDPService getCatalogItemPDP;

        public ProductController(IGetCatalogItemPLPService getCatalogItemPLPService,IGetCatalogItemPDPService getCatalogItemPDP)
        {
            this.getCatalogItemPLPService = getCatalogItemPLPService;
            this.getCatalogItemPDP = getCatalogItemPDP;
        }
        public IActionResult Index(CatalogPLPRequestDto catalogPLPRequestDto)
        {
            var data = getCatalogItemPLPService.Execute(catalogPLPRequestDto);
            return View(data);
        }

        public IActionResult Detail(string Slug)
        {
            var data = getCatalogItemPDP.Execute(Slug);
            return View(data);
        }
    }
}
