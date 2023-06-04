using Application.Interfase.Context;
using Domain.Order;
using Domain.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments
{
    public interface IPaymentService
    {
        PaymentOfOrderDto PaymentForOrder(int OrderId);
        PaymentDto GetPayment(Guid Id);
    }

    public class PaymentService : IPaymentService
    {
        private readonly IDataBaseContext context;
        private readonly IIdentityDataBaseContext identityDataBaseContext;

        public PaymentService(IDataBaseContext context, IIdentityDataBaseContext identityDataBaseContext)
        {
            this.context = context;
            this.identityDataBaseContext = identityDataBaseContext;
        }

        public PaymentDto GetPayment(Guid Id)
        {
            var payement = context.Payments
                .Include(p => p.Order)
                .ThenInclude(p => p.OrderItems)
                .SingleOrDefault(p => p.Id == Id);


            var user = identityDataBaseContext.Users.SingleOrDefault(p => p.Id == payement.Order.UserId);

            string description = $" پرداخت سفارش شماره{payement.OrderId}" + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;

            foreach (var item in payement.Order.OrderItems.Select(p => p.ProductName))
            {
                description += $" - {item} ";
            }
            PaymentDto PaymentDto = new PaymentDto
            {
                Amount = payement.Order.TotalPrice(),
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Description = description,
            };

            return PaymentDto;
        }
        public PaymentOfOrderDto PaymentForOrder(int OrderId)
        {
            var order = context.Orders
                .Include(p => p.OrderItems)
                .SingleOrDefault(p => p.Id == OrderId);
            if (order == null)
                throw new Exception("");

            var payment = context.Payments.SingleOrDefault(p => p.OrderId == order.Id);

            if (payment == null)
            {
                payment = new payment(order.TotalPrice(), order.Id);
                context.Payments.Add(payment);
                context.SaveChanges();
            }
            return new PaymentOfOrderDto
            {
                Amount = payment.Amount,
                PaymentId = payment.Id,
                PaymentMethod = order.PaymentMethod
            };
        }

        public bool VerifyPayment(Guid Id, string Authority, long RefId)
        {
            var payment = context.Payments
       .Include(p => p.Order)
       .SingleOrDefault(p => p.Id == Id);

            if (payment == null)
                throw new Exception("payment not found");

            payment.PaymentIsDone(Authority, RefId);

            context.SaveChanges();
            return true;
        }
    }
    public class PaymentOfOrderDto
    {
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }

    public class PaymentDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
        public string UserId { get; set; }
    }

}
