using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.Ground_SectionController
{
    public class Ground_SectionController : Controller
    {
        private readonly IGround_Section _ground_section;
        private readonly ICity _sity;

        [HttpGet]
        public IActionResult Ground_SectionView()
        {
            return View();
        }
    }
}