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
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
           this.userManager = userManager;
            this.signInManager = signInManager;
        }

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        // // // /////////////////////////////
       //Logout user

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        // // // /////////////////////////////
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
                var user = new IdentityUser
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
           // model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList;
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

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var code = "token";
                var result = await userManager.ResetPasswordAsync(user, code, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);

        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
               // if (user == null || await userManager.IsEmailConfirmedAsync(user));

            }


            return View("ForgetPasswordConfirmation");

        }
        public IActionResult ForgetPasswordConfirmation()
        {
            return View();
        }

    }
}
