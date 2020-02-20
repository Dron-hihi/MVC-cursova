using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CursovaMVC.Data.EFContext;
using CursovaMVC.Data.Models;
using CursovaMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}