using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using CursovaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.OfficeController
{
    public class OfficeController : Controller
    {
        private readonly IOffice _office;
        private readonly ICity _sity;

        public OfficeController(IOffice office)
        {
            _office = office;
        }

        [HttpGet]
        public IActionResult OfficeView()
        {
            IEnumerable<Office> offices = null;
            offices = _office.GetOffices.OrderBy(i => i.Id);
            var officeObj = new OfficeViewModel
            {
                GetOffices = offices
            };
            return View(officeObj);
        }
    }
}