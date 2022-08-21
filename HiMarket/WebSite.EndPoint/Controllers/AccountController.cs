using Application.Services.Email;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebSite.EndPoint.Models.Register;
using WebSite.EndPoint.Models.ViewModels.User;

namespace WebSite.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly EmailServices _emailServices;
        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailServices = new EmailServices();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            User newuser = new User()
            {
                FullName = register.FullName,
                Email = register.Email,
                UserName = register.Email,
                PhoneNumber = register.PhoneNumber,
            };

            var result = _userManager.CreateAsync(newuser, register.Password).Result;
            if (result.Succeeded)
            {
                var token = _userManager.GenerateEmailConfirmationTokenAsync(newuser).Result;
                string callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    UserId = newuser.Id
              ,
                    token = token
                }, protocol: Request.Scheme);

                string body = $"لطفا برای فعال حساب کاربری بر روی لینک زیر کلیک کنید!  <br/> <a href={callbackUrl}> Link </a>";
                _emailServices.Execute(newuser.Email, body, "فعال سازی حساب کاربری های مارکت");

                return RedirectToAction("DisplayEmail");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
        
            return View(register);

        }

        public IActionResult DisplayEmail()
        {
            return View();
        }

        public IActionResult ConfirmEmail(string UserId, string Token)
        {
            if (UserId == null || Token == null)
            {
                return BadRequest();
            }

            var user = _userManager.FindByIdAsync(UserId).Result;

            if (user == null)
            {
                return View("Error");
            }

            var result = _userManager.ConfirmEmailAsync(user, Token).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("login");
            }

            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPassword);
            }

            var user = _userManager.FindByEmailAsync(forgotPassword.Email).Result;
            if (user == null || _userManager.IsEmailConfirmedAsync(user).Result == false)
            {
                ViewBag.message = "ممکن است ایمیل وارد شده معتبر نباشد! و یا اینکه ایمیل خود را تایید نکرده باشید";
                return View();
            }

            string token = _userManager.GeneratePasswordResetTokenAsync(user).Result;

            string callbakUrl = Url.Action("ResetPassword", "Account", new
            {
                token = token,
                UserId = user.Id
            }, protocol: Request.Scheme);

            string body = $"برای تنظیم مجدد کلمه عبور بر روی لینک زیر کلیک کنید <br/> <a href={callbakUrl}> link reset Password </a>";
            _emailServices.Execute(user.Email, body, "فراموشی رمز عبور");
            ViewBag.meesage = "لینک تنظیم مجدد کلمه عبور برای ایمیل شما ارسال شد";

            return View();
        }

        public IActionResult ResetPassword(string userId,string token)
        {
            return View(new ResetPasswordViewModel
            {
                UserId = userId,
                Token= token
            });
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (!ModelState.IsValid)
                return View(resetPassword);
            if (resetPassword.Password != resetPassword.ConfirmPassword)
            {
                return BadRequest();
            }
            var user = _userManager.FindByIdAsync(resetPassword.UserId).Result;
            if (user == null)
            {
                return BadRequest();
            }
            var Result = _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password).Result;
            if (Result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Errors = Result.Errors;
                return View(resetPassword);
            }
        }


        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userManager.FindByNameAsync(login.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return View(login);
            }

            _signInManager.SignOutAsync();
            var result = _signInManager.PasswordSignInAsync(user, login.Password, login.IsPersistent, true).Result;
            if (result.Succeeded)
            {
                return Redirect(login.ReturnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                //
            }

            return View(login);
        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
