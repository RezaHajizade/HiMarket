using Application.Catalogs.CatalogItems.CatalogItemServices;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Customers.Controllers
{
    

    [Authorize]
    [Area("Customers")]
    public class MyFavouriteController : Controller
    {

        private readonly ICatalogItemService catalogItemService;
        private readonly UserManager<User> userManager;

        public MyFavouriteController(ICatalogItemService catalogItemService
            , UserManager<User> userManager)
        {
            this.catalogItemService = catalogItemService;
            this.userManager = userManager;
        }
        public IActionResult Index(int page = 1, int pageSize = 20)
        {
            var user = userManager.GetUserAsync(User).Result;
            var data = catalogItemService.GetMyFavourite(user.Id, page, pageSize);
            return View(data);
        }

        public IActionResult AddToMyFavourite(int CatalogItemId)
        {
            var user = userManager.GetUserAsync(User).Result;
            catalogItemService.AddToMyFavourite(user.Id, CatalogItemId);
            return RedirectToAction(nameof(Index));
        }
    }
}
