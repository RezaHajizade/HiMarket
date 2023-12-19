using Application.BasketService;
using Application.Discounts;
using Application.Orders;
using Application.Payments;
using Application.Users;
using Domain.Entity;
using Domain.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebSite.EndPoint.Models.ViewModels.Baskets;
using WebSite.EndPoint.Utilities;


namespace WebSite.EndPoint.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private readonly IUserAddressService userAddressService;
        private readonly IOrderService orderService;
        private readonly IPaymentService paymentService;
        private readonly IDiscountService discountService;
        private string userId = null;

        public BasketController(IBasketService basketService,
            SignInManager<User> signInManager,
            IUserAddressService userAddressService,
            IOrderService orderService,
            IPaymentService paymentService,
            IDiscountService discountService)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
            this.userAddressService = userAddressService;
            this.orderService = orderService;
            this.paymentService = paymentService;
            this.discountService = discountService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(int catalogItemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            basketService.AddItemToBasket(basket.Id, catalogItemId, quantity);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RemoveItemFromBasket(int itemId)
        {
            basketService.RemoveItemFromBasket(itemId);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult setQuantity(int basketItemId, int quantity)
        {
            return Json(basketService.SetQuantity(basketItemId, quantity));
        }

        public IActionResult ShippingPayment()
        {
            ShippingPaymentVIewModel model = new ShippingPaymentVIewModel();
            string userId = ClaimUtility.GetUserId(User);
            model.Basket = basketService.GetBasketForUser(userId);
            model.UserAddresses = userAddressService.GetAddress(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult ShippingPayment(int Address, PaymentMethod PaymentMethod)
        {
            string UserId = ClaimUtility.GetUserId(User);
            var Basket = basketService.GetBasketForUser(UserId);
            var OrderId = orderService.CreateOrder(Basket.Id, Address, PaymentMethod);

            if (PaymentMethod == PaymentMethod.OnlinePayment)
            {
                //Registration Orders
                var Payment = paymentService.PaymentForOrder(OrderId);

                //Send to payment gateway
                return RedirectToAction("Index", "Pay", new { PaymentId = Payment.PaymentId });
            }
            else
            {
                //Go to my orders page
                return RedirectToAction("Index", "Orders", new { area = "Customers" });
            }

        }

        public IActionResult Checkout()
        {
            return View();
        }

        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                userId = ClaimUtility.GetUserId(User);
                return basketService.GetOrCreateBasketForUser(userId);
            }
            else
            {
                SetCookiesForBasket();
                return basketService.GetOrCreateBasketForUser(userId);
            }
        }
        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                userId = Request.Cookies[basketCookieName];
            }
            if (userId != null) return;
            userId = Guid.NewGuid().ToString();
            var cookieOption = new CookieOptions { IsEssential = true };
            cookieOption.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Append(basketCookieName, userId, cookieOption);

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ApplyDiscount(string CouponCode,int BasketId)
        {
            discountService.ApplyDiscountInBasket(CouponCode, BasketId);

            return RedirectToAction(nameof(Index));

        }
        [AllowAnonymous]
        public IActionResult RemoveDiscount(int Id)
        {
            discountService.RemoveDiscountFromBasket(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
