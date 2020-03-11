using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CursovaMVC.Data.EFContext;
using CursovaMVC.Data.Models;
using CursovaMVC.Models;
using CursovaMVC.Services;
using CursovaMVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CursovaMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly RoleManager<DbRole> _roleManager;
        private readonly EFDBContext _context;

        public AccountController(UserManager<DbUser> userManager, SignInManager<DbUser> signInManager,
            RoleManager<DbRole> roleManager, EFDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            var roleName = "User";

            //var result = _roleManager.CreateAsync(new DbRole
            //{
            //    Name = roleName
            //}).Result;
            //roleName = "Rieltor";
            //result = _roleManager.CreateAsync(new DbRole
            //{
            //    Name = roleName
            //}).Result;
            //roleName = "Admin";
            //result = _roleManager.CreateAsync(new DbRole
            //{
            //    Name = roleName
            //}).Result;

            if (ModelState.IsValid)
            {
                var userE = _context.Users.FirstOrDefault(x => x.Email == model.Email);
                if (userE != null)
                { 

                    return View(model);
                }
                if (model.FirstName == null)
                {
                    return View(model);
                }

                UserProfile userProfile = new UserProfile
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    RegistrationDate = DateTime.Now
                };
                DbUser dbUser = new DbUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    UserProfile = userProfile
                };
                var res = await _userManager.CreateAsync(dbUser, model.Password);
                res = _userManager.AddToRoleAsync(dbUser, roleName).Result;

                if (res.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(dbUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "No corected login");
                return View(model);
            }

            var result = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "No corected password");
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            //////Session
            var userInfo = new UserInfo()
            {
                UserId = user.Id,
                Email = user.Email
            };
            HttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(userInfo));

            await Authenticate(model.Email);

            //////
            return RedirectToAction("Index", "Home");
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        /////no admin
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        [Route("Account/ChangePassword/{id}")]
        public IActionResult ChangePassword(string id)
        {
            return View();
        }

        [HttpPost]
        [Route("Account/ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    ModelState.AddModelError("", "This User not register");
                    return View(model);
                }

                var hash_password = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.PasswordHash = hash_password;
                var result = await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Ця електронна почта не зареєстрована");
                    return View(model);
                }

                var userName = user.Email;

                EmailService emailService = new EmailService();
                string url = "http://localhost:57206/Account/ChangePassword/" + user.Id;

                await emailService.SendEmailAsync(model.Email, "ForgotPassword",
                    $" Dear {userName}," +
                    $" <br/>" +
                    $" To change your password" +
                    $" <br/>" +
                    $" Зміна паролю <a href='{url}'>press</a>");
            }
            return View();
        }
    }
}