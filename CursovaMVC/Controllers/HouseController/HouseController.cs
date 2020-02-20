using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.HouseController
{
    public class HouseController : Controller
    {
        private readonly IHouse _house;
        private readonly IHouse_Type _house_type;
        private readonly ICity _sity;


        public IActionResult Index()
        {
            return View();
        }
    }
}