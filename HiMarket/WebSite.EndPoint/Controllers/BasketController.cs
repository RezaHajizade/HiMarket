using Application.BasketService;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace WebSite.EndPoint.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private string UserId = null;

        public BasketController(IBasketService basketService,
            SignInManager<User> signInManager)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var data=GetOrSetBasket();
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(int catalogItemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            basketService.AddItemToService(basket.Id, catalogItemId, quantity);
            return RedirectToAction(nameof(Index));
        }

        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                return basketService.GetOrCreateBasketForUser(User.Identity.Name);
            }
            else
            {
                SetCookiesForBasket();
                return basketService.GetOrCreateBasketForUser(UserId);
            }
        }
        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                UserId = Request.Cookies[basketCookieName];
            }
            if (UserId != null) return;
            UserId = Guid.NewGuid().ToString();
            var cookieOption = new CookieOptions { IsEssential = true };
            cookieOption.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Append(basketCookieName, UserId, cookieOption);

        }

    }
}
