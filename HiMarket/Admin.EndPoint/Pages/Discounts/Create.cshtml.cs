using Application.Discounts.AddNewDiscountService;
using Application.Interfase.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Discounts
{
    public class CreateModel : PageModel
    {
        private readonly IAddNewDiscountService addNewDiscountService;

        public CreateModel(IAddNewDiscountService addNewDiscountService)
        {
            this.addNewDiscountService = addNewDiscountService;
        }

        [BindProperty]
        public AddNewDiscountDto model { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            addNewDiscountService.Execute(model);
        }
    }
}
