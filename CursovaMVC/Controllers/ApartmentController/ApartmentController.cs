using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using CursovaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.ApartmentController
{
    public class ApartmentController : Controller
    {
        private readonly IApartment _apartment;
        private readonly IHouse_Type _house_type;
        private readonly ICity _sity;
        public ApartmentController(IApartment apartment)
        {
            _apartment = apartment;
        }

        [HttpGet]
        public IActionResult ApartmentView()
        {
            IEnumerable<Apartment> apartments = null;

            apartments = _apartment.GetApartments.OrderBy(i => i.Id);
            var apartObj = new ApartmentViewModel
            {
                GetApartments = apartments
            };
            
            return View(apartObj);
        }
    }
}