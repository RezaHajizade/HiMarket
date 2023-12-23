using Application.Dtos;
using Application.Interfase.Context;
using Domain.Discounts;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Discounts
{
    public interface IDiscountService
    {
        List<CatalogItemDto> GetCatalogItems(string searchKey);
        bool ApplyDiscountInBasket(string CoponCode, int BasketId);
        bool RemoveDiscountFromBasket(int BasketId);
        BaseDto IsDiscountValid(string  CoponCode, User user);
    }

    public class DiscountService : IDiscountService
    {
        private readonly IDataBaseContext context;
        private readonly IDiscountHistoryService discountHistoryService;

        public DiscountService(IDataBaseContext context
            ,IDiscountHistoryService discountHistoryService)
        {
            this.context = context;
            this.discountHistoryService = discountHistoryService;
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

        public BaseDto IsDiscountValid(string CoponCode, User user)
        {
            var discount = context.Discount
                .Where(p => p.CouponCode.Equals(CoponCode)).FirstOrDefault();

            if(discount == null)
            {
                return new BaseDto(IsSuccess: false,
                    Message: new List<string> { "کد تخفیف معتبر نمی باشد" });
            }

            var now = DateTime.UtcNow;
            if(discount.StartDate.HasValue)
            {
                var startDate=DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                if (startDate.CompareTo(now) > 0)
                {
                    return new BaseDto(IsSuccess: false,
                        Message:new List<string>{ "هنوز زمان استفاده از این کد تخفیف فرا نرسیده است"});
                }

            }

            if (discount.EndDate.HasValue)
            {
                var endDate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
                if (endDate.CompareTo(now) < 0)
                {
                    return new BaseDto(IsSuccess: false,
                        Message: new List<string> { "کد تخفیف منقضی شده است" });
                }

            }

            if (discount.EndDate.HasValue)
            {
                var endDate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
                if (endDate.CompareTo(now) < 0)
                {
                    return new BaseDto(IsSuccess: false,
                        Message: new List<string> { "هنوز زمان استفاده از این کد تخفیف فرا نرسیده است" });
                }

            }

            var checkLimit = CheckDiscountLimitation(discount, user);
            if (checkLimit.IsSuccess == false)
                return checkLimit;
            return new BaseDto(true, null);

        }
        private BaseDto CheckDiscountLimitation(Discount discount, User user)
        {
            switch (discount.DiscountLimitation)
            {
                case DiscountLimitationType.Unlimited:
                    {
                        return new BaseDto(IsSuccess:true,null);
                    }
                case DiscountLimitationType.NTimesOnly:
                    {
                        var totalUsage = discountHistoryService.GetAllDiscountUsageHistory(discount.Id,null,0,1).Data.Count();
                        if(totalUsage<discount.LimitationTimes)
                        {
                            return new BaseDto(IsSuccess: true, null);
                        }
                        else
                        {
                            return new BaseDto(IsSuccess: false, Message: new List<string> { "ظرفیت استفاده از این کد تخفیف تکمیل شده است" });
                        }
                    }

                case DiscountLimitationType.NTimesPerCustomer:
                   if(user!=null)
                    {
                        var totalUsage = discountHistoryService.GetAllDiscountUsageHistory(discount.Id, user.Id, 0, 1).Data.Count();
                        if(totalUsage<discount.LimitationTimes)
                        {
                            return new BaseDto(IsSuccess: true, null);
                        }
                        else
                        {
                            return new BaseDto(IsSuccess: false, Message: new List<string> { "تعدادی که شما مجاز به استفاده از این کد تخفیف بوده اید به پایان رسیده است" });
                        }
                        
                    }
                    else
                    {
                        return new BaseDto(true, null);
                    }           
                default:
                    break;
            }
            return new BaseDto(true, null);
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
