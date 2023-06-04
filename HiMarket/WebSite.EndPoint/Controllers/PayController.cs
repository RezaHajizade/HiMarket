using Application.Payments;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using WebSite.EndPoint.Utilities;
using ZarinPal.Class;

namespace WebSite.EndPoint.Controllers
{
    public class PayController : Controller
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IConfiguration configuration;
        private readonly IPaymentService paymentService;
        private readonly string merchendId;

        public PayController(IConfiguration configuration,IPaymentService paymentService)
        {
            this.configuration = configuration;
            this.paymentService = paymentService;
            merchendId = configuration["ZarinpalMerchendId"];


            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();         
        }

        public async Task<IActionResult> Index(Guid paymentId)
        {
            var payment=paymentService.GetPayment(paymentId);
            if(payment == null)
            {
                return NotFound();
            }

            var userId = ClaimUtility.GetUserId(User);

            if(userId != payment.UserId)
            {
                return BadRequest();
            }

            string callBackUrl=Url.Action(nameof(Verify),"Pay",new {paymentId},protocol:Request.Scheme);

            var resultZarinpalRequest = await _payment.Request(new DtoRequest()
            {
                Amount = payment.Amount,
                Description = payment.Description,
                Email = payment.Email,
                MerchantId = merchendId,
                Mobile = payment.PhoneNumber,
                CallbackUrl = callBackUrl
            },Payment.Mode.zarinpal
            );
            return Redirect($"https://zarinpal.com/pg/StartPay/{resultZarinpalRequest.Authority}");
        }

        public IActionResult Verify()
        {
            return View();
        }
    }
}
