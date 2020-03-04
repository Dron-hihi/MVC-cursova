using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.OfficeController
{
    public class OfficeController : Controller
    {
        private readonly IOffice _office;
        private readonly ICity _sity;

        [HttpGet]
        public IActionResult OfficeView()
        {
            return View();
        }
    }
}