using Application.BasketService;
using Application.Users;

namespace WebSite.EndPoint.Models.ViewModels.Baskets
{
    public class ShippingPaymentVIewModel
    {
        public BasketDto Basket { get; set; }
        public List<UserAddressDto> UserAddresses { get; set; } 

    }
}
