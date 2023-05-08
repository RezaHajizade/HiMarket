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
        void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);
        bool RemoveItemFromBasket(int ItemId);
        bool SetQuantity(int quantity, int itemId);
        BasketDto GetBasketForUser(string UserId);
        void TransferBasket(string anonymousId, string UserId);

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

        public void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1)
        {
            var basket = context.Baskets.FirstOrDefault(b => b.Id == basketId);
            if (basket == null)
                throw new Exception("");
            var catalog = context.CatalogItems.Find(catalogItemId);
            basket.AddItem(catalog.Price, quantity, catalogItemId);
            context.SaveChanges();
        }

        public BasketDto CreateBasketForUser(string UserId)
        {
            var Basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(b => b.BuyerId == UserId);

            if (Basket == null)
            {
                return null;
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

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var Basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .FirstOrDefault(p => p.BuyerId == BuyerId);

            if (Basket == null)
            {
                //create basket of buy
                return GetOrCreateBasketForUser(BuyerId);
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

        public BasketDto GetBasketForUser(string UserId)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .FirstOrDefault(p => p.BuyerId == UserId);

            if(basket == null)
            {
                return null;
            }

            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                basketItems = basket.Items.Select(item => new BasketItemDto
                {
                    CatalogItemId = item.Id,
                    CatalogName = item.CatalogItem.Name,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    ImageUrl = uriComposerService.ComposeImageUri(item?.CatalogItem?
                     .CatalogItemImages?.FirstOrDefault()?.Src ?? ""),
                }).ToList(),
            };
        }

        public void TransferBasket(string anonymousId, string UserId)
        {
            var anonymousBasket = context.Baskets
                .FirstOrDefault(p => p.BuyerId == anonymousId);

            if(anonymousBasket==null) return;

            var userBasket = context.Baskets.SingleOrDefault(p => p.BuyerId == UserId);
            if (userBasket == null)
            {
                userBasket = new Baskets(UserId);
                context.Baskets.Add(userBasket);
            }

            foreach(var item in anonymousBasket.Items)
            {
                userBasket.AddItem(item.UnitPrice,item.Quantity,item.CatalogItemId);
            }

            context.Baskets.Remove(anonymousBasket);

            context.SaveChanges();
        }
    }

    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> basketItems { get; set; } = new List<BasketItemDto>();
        public int Total()
        {
            if(basketItems.Count>0)
            {
                return basketItems.Sum(p => p.UnitPrice * p.Quantity);
            }
            return 0;
        }

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
