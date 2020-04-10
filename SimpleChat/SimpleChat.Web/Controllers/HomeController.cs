using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleChat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;

        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }


        public IActionResult Index()
        {
            
            if (User == null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Chat/Index");
            }
         
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult>  Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
               var singInResult = await _singInManager.PasswordSignInAsync( user, password,false,false);
                if (singInResult.Succeeded)
                {
                    return Redirect("~/Chat/Index");
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = new IdentityUser
            {
                UserName = username
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var singInResult = await _singInManager.PasswordSignInAsync(user, password, false, false);
                if (singInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Index");
        }
 

        public async Task<IActionResult> LogOut()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
