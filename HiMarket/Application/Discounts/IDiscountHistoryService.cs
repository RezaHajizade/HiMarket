using Application.Dtos;
using Application.Interfase.Context;
using Commons;
using Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Discounts
{
    public interface IDiscountHistoryService
    {
        void InsertDiscountUsageHistory(int DiscountId, int OrderId);
        DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryById);
        PaginatedItemDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId, string? userId, int pageSize, int pageIndex);
    }


    public class DiscountHistoryService : IDiscountHistoryService
    {
        private readonly IDataBaseContext context;

        public DiscountHistoryService(IDataBaseContext context)
        {
            this.context = context;
        }

        public PaginatedItemDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId, string? userId, int pageSize, int pageIndex)
        {
            var query = context.DiscountUsageHistory.AsQueryable();

            if (discountId.HasValue && discountId.Value > 0)
                query = query.Where(p => p.DiscountId == discountId.Value);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(p => p.Order != null && p.Order.UserId == userId);

            query = query.OrderByDescending(c => c.CreateOn);
            var pagedItems = query.PagedResult(pageIndex, pageSize, out int rowCount);
            return new PaginatedItemDto<DiscountUsageHistory>(pageIndex, pageSize, rowCount, query.ToList());
        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryById)
        {

            if (discountUsageHistoryById == 0)
                return null;

            var discountUsage = context.DiscountUsageHistory.Find(discountUsageHistoryById);
            return discountUsage;
        }

        public void InsertDiscountUsageHistory(int DiscountId, int OrderId)
        {
            var discount = context.Discount.Find(DiscountId);

            var order=context.Orders.Find(OrderId);

            DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory()
            {
                CreateOn = DateTime.Now,
                Discount = discount,
                Order = order
            };

            context.DiscountUsageHistory.Add(discountUsageHistory);
            context.SaveChanges();

        }
    }
}
