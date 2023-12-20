using Application.Discounts;
using Application.Interfase.Context;
using Application.UriComposer;
using AutoMapper;
using Domain.Baskets;
using Domain.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders
{
    public interface IOrderService
    {
        int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);
    }

    public class OrderService : IOrderService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;
        private readonly IDiscountHistoryService discountHistoryService;

        public OrderService(IDataBaseContext context,
            IMapper mapper,
            IUriComposerService uriComposerService,
            IDiscountHistoryService discountHistoryService)
        {
            this.context = context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
            this.discountHistoryService = discountHistoryService;
        }
        public int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .Include(p => p.AppliedDiscount)
                .SingleOrDefault(p => p.Id == BasketId);


            int[] Ids = basket.Items.Select(p => p.CatalogItemId).ToArray();
            var catalogItems = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .Where(p => Ids.Contains(p.Id));

            var orderItems = basket.Items.Select(basketitem =>
            {
                var catalogitem = catalogItems.First(c => c.Id == basketitem.CatalogItemId);

                var orderitem = new OrderItem(catalogitem.Id,
                    catalogitem.Name,
                    uriComposerService.ComposeImageUri(catalogitem?.CatalogItemImages?.FirstOrDefault().Src ?? ""),
                    catalogitem.Price,
                    basketitem.Quantity);

                return orderitem;
            }).ToList();

            var userAddress = context.UserAddress.SingleOrDefault(p => p.Id == UserAddressId);

            var address = mapper.Map<Address>(userAddress);
            var order = new Order(basket.BuyerId, address, orderItems, paymentMethod, basket.AppliedDiscount);
            context.Orders.Add(order);
            context.Baskets.Remove(basket);
            context.SaveChanges();

            if (basket.AppliedDiscount != null)
            {
                discountHistoryService.InsertDiscountUsageHistory(basket.Id, order.Id);
            }

            return order.Id;
        }
    }

}
