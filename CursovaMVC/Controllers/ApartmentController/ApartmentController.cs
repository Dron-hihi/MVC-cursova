using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.ApartmentController
{
    public class ApartmentController : Controller
    {
        private readonly IApartment _apartment;
        private readonly IHouse_Type _house_type;
        private readonly ISity _sity;


        public IActionResult Index()
        {
            return View();
        }
    }
}