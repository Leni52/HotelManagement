using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
           this.userManager = userManager;
            this.signInManager = signInManager;
        }

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        // // // /////////////////////////////
       //Logout user

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        //////////////////////////////////////
        ///Remote validation(is the user name unique)
        // // // /////////////////////////////

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
      var user =  await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            { return Json($"Email: {email} is already in use."); }
        }


        //Register User
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email

                };
                var result =  await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //persistent cookie: false
                   await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        // // // /////////////////////////////
        //LOGIN
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);
                   
                if (result.Succeeded)
                {
                  return RedirectToAction("index", "home");
                }
             ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            

            return View(model);
        }
        // // // /////////////////////////////

        //RESET PASSWORD
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if(token==null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token.");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach( var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);

                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                        new { email = model.Email, token = token }, Request.Scheme);




                    return View("ForgetPasswordConfirmation");
                }
                return View("ForgetPasswordConfirmation");
            }
            return View(model);

        }
        public IActionResult ForgetPasswordConfirmation()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
