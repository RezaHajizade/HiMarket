using Application.Catalogs.CatalogItems.UriComposer;
using Application.Interfase.Context;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BasketService
{
    public interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToService(int basketId, int catalogItemId, int quantity = 1);
        bool RemoveItemFromBasket(int ItemId);
        bool SetQuantity(int quantity, int itemId);
    }
    public class BasketService : IBasketService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;

        public BasketService(IDataBaseContext context, IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }

        public void AddItemToService(int basketId, int catalogItemId, int quantity = 1)
        {
            var basket = context.Baskets.FirstOrDefault(b => b.Id == basketId);
            if (basket == null)
                throw new Exception("");
            var catalog = context.CatalogItems.Find(catalogItemId);
            basket.AddItem(catalog.Price, quantity, catalogItemId);
            context.SaveChanges();
        }

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var Basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(b => b.BuyerId == BuyerId);

            if (Basket == null)
            {
                //create basket of buy
                return CreateBasketForUser(BuyerId);
            }

            return new BasketDto
            {
                BuyerId = Basket.BuyerId,
                Id = Basket.Id,
                basketItems = Basket.Items.Select(item => new BasketItemDto
                {
                    Id = item.Id,
                    CatalogItemId = item.CatalogItemId,
                    CatalogName = item.CatalogItem.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ImageUrl = uriComposerService.ComposeImageUri(item?.CatalogItem?.CatalogItemImages?.FirstOrDefault()?.Src ?? "")
                }).ToList(),
            };
        }

        public bool RemoveItemFromBasket(int ItemId)
        {
            var item = context.BasketItems.SingleOrDefault(p => p.Id == ItemId);
            context.BasketItems.Remove(item);
            context.SaveChanges();
            return true;
        }

        public bool SetQuantity(int itemId, int quantity)
        {
            var item = context.BasketItems.SingleOrDefault(p => p.Id == itemId);
            item.SetQuantity(quantity);
            context.SaveChanges();
            return true;
        }

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Baskets bascket = new Baskets(BuyerId);
            context.Baskets.Add(bascket);
            context.SaveChanges();
            return new BasketDto
            {
                BuyerId = bascket.BuyerId,
                Id = bascket.Id
            };
        }
    }

    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> basketItems { get; set; } = new List<BasketItemDto>();
    }

    public class BasketItemDto
    {
        public int Id { get; set; }
        public int CatalogItemId { get; set; }
        public string CatalogName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
