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
    public  interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
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
        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var Basket = context.basckets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(b => b.BuyerId == BuyerId);

            if(Basket==null)
            {
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
        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Bascket bascket=new Bascket(BuyerId);
            context.basckets.Add(bascket);
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
        public List<BasketItemDto> basketItems { get; set; }=new List<BasketItemDto>();
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
