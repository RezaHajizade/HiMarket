using Domain.Attributes;
using Domain.Catalogs;
using Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Baskets
{
    [Auditable]
    public class Baskets
    {
        public int Id { get; set; }
        public string BuyerId { get; private set; }

        private readonly List<BasketItem> _items = new List<BasketItem>();

        public int DiscountAmount { get; private set; } = 0;
        public Discount AppliedDiscount {  get; private set; }
        public int? AppliedDiscountId { get; private set; }



        public ICollection<BasketItem> Items => _items.AsReadOnly();
        public Baskets(string buyerId)
        {
            BuyerId = buyerId;
        }


        public void AddItem(int unitPrice, int quantity, int catalogItemId)
        {
            if (!Items.Any(p => p.CatalogItemId == catalogItemId))
            {
                _items.Add(new BasketItem(unitPrice, quantity, catalogItemId));
                return;
            }
            var existingItem = Items.FirstOrDefault(p => p.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }

        public int TotalPrice()
        {
            int totalPrice=_items.Sum(p=>p.UnitPrice*p.Quantity);
            totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }

        public int TotalPriceWithOutDiscount()
        {
            int totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            return totalPrice;
        }
        public void ApplyDiscountCode(Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmount = discount.GetDiscountAmount(TotalPriceWithOutDiscount());
        }

        public void RemoveDicount()
        {
            AppliedDiscount = null;
            AppliedDiscountId = null;
            DiscountAmount = 0;
        }
    }

    [Auditable]
    public class BasketItem
    {
        public int Id { get; set; }
        public int Quantity { get; private set; }
        public int UnitPrice { get; private set; }
        public int CatalogItemId { get; private set; }
        public CatalogItem CatalogItem { get; private set; }
        public int BascketId { get; private set; }
        public BasketItem(int unitPrice, int quantity, int catalogItemId)
        {
            SetQuantity(quantity);
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

    }
}
