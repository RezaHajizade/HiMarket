using Application.BasketService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint.Models.ViewComponents
{
    public class BasketComponent : ViewComponent
    {
        private readonly IBasketService basketService;
        private ClaimsPrincipal userClaimPrincipal => ViewContext?.HttpContext?.User;
        public BasketComponent(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        public IViewComponentResult Invoke()       
        {
            BasketDto basket = null;
            if (User.Identity.IsAuthenticated)
            {
                basket = basketService.GetBasketForUser(ClaimUtility.GetUserId(userClaimPrincipal));
            }
            else
            {
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    var buyerId = Request.Cookies[basketCookieName];
                    basket = basketService.GetBasketForUser(buyerId);
                }
            }
            return View(viewName: "BasketComponent", model: basket);
        }
    }
}
