using Domain.Attributes;
using Domain.Catalogs;
using Domain.Discounts;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order
{
    [Auditable]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public Address Address { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal DiscountAmount { get; private set; }
        public Discount AppliedDiscount { get;private set; }
        public int? AppliedDiscountId { get;private set; }

        public Order(string userId, Address address, List<OrderItem> orderItems
            , PaymentMethod paymentMethod
            , Discount discount)

        {
            UserId = userId;
            Address = address;
            _orderItems = orderItems;
            PaymentMethod = paymentMethod;
            if (discount != null)
            {
                ApplyDiscountCode(discount);
            }
        }
        public Order()
        {

        }


        public int TotalPrice()
        {
            int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
            totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }

        /// <summary>
        /// دریافت مبلغ کل بدون درنظر گرفتن کد تخفیف
        /// </summary>
        /// <returns></returns>
        public int TotalPriceWithOutDiscount()
        {
            int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
            return totalPrice;
        }

        public void ApplyDiscountCode(Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmount = discount.GetDiscountAmount(TotalPrice());
        }

        /// <summary>
        /// Payment is done
        /// </summary>
        public void PaymentDone()
        {
            PaymentStatus = PaymentStatus.Paid;
        }

        /// <summary>
        /// The goods were delivered
        /// </summary>
        public void OrderDelivered()
        {
            OrderStatus = OrderStatus.Delivered;
        }

        /// <summary>
        /// Product return registration
        /// </summary>
        public void OrderReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }

        /// <summary>
        /// Cancel the order
        /// </summary>        
        public void OrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }

    }
    [Auditable]
    public class OrderItem
    {
        public int Id { get; set; }
        public CatalogItem catalogItem { get; set; }
        public int CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }

        public OrderItem(int catalogItemId, string productName, string pictureUri,
            int unitPrice, int units)
        {
            CatalogItemId = catalogItemId;
            ProductName = productName;
            PictureUri = pictureUri;
            UnitPrice = unitPrice;
            Units = units;
        }
        //ef core
        public OrderItem()
        {

        }
    }

    public class Address
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string ReciverName { get; private set; }

        public Address(string state, string city, string zipCode, string postalAddress, string reciverName)
        {
            State = state;
            City = city;
            ZipCode = zipCode;
            PostalAddress = postalAddress;
            ReciverName = reciverName;
        }
    }

    public enum PaymentMethod
    {
        /// <summary>
        /// online payment
        /// </summary>
        OnlinePayment = 0,

        ///<summary>
        ///Payment on the spot
        /// </summary>
        PaymentOnTheSpot = 1,
    }

    public enum PaymentStatus
    {
        ///<summary>
        ///Awaiting payment
        /// </summary>
        WaitingForPayment = 0,

        ///<summary>
        ///Payment is done
        /// </summary>
        Paid = 1,
    }

    public enum OrderStatus
    {
        ///<summary>
        ///Processing
        /// </summary>
        Processing = 0,

        ///<summary>
        ///delivered
        /// </summary>
        Delivered = 1,

        ///<summary>
        ///returned
        /// </summary>
        Returned = 2,

        ///<summary>
        ///Cancelled
        /// </summary>
        Cancelled = 3,
    }

}
