using Application.Dtos;
using Application.Interfase.Context;
using Domain.Discounts;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Discounts
{
    public interface IDiscountService
    {
        List<CatalogItemDto> GetCatalogItems(string searchKey);
        bool ApplyDiscountInBasket(string CoponCode, int BasketId);
        bool RemoveDiscountFromBasket(int BasketId);
    }

    public class DiscountService : IDiscountService
    {
        private readonly IDataBaseContext context;

        public DiscountService(IDataBaseContext context)
        {
            this.context = context;
        }

        public bool ApplyDiscountInBasket(string CoponCode, int BasketId)
        {
            var basket = context.Baskets
               .Include(p => p.Items)
               .Include(p => p.AppliedDiscount)
               .FirstOrDefault(p => p.Id == BasketId);

            var discount = context.Discount.Where(p => p.CouponCode.Equals(CoponCode))
                .FirstOrDefault();

            basket.ApplyDiscountCode(discount);
            context.SaveChanges();
            return true;
        }

        public List<CatalogItemDto> GetCatalogItems(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                var data = context.CatalogItems
                    .Where(p => p.Name.Contains(searchKey))
                    .Select(p => new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();
                return data;
            }
            else
            {
                var data = context.CatalogItems
                    .OrderByDescending(p => p.Id)
                    .Take(10)
                    .Select(p => new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();
                return data;
            }

        }

        public bool RemoveDiscountFromBasket(int BasketId)
        {
            var basket = context.Baskets.Find(BasketId);
            basket.RemoveDicount();
            context.SaveChanges();
            return true;

        }
    }
    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
