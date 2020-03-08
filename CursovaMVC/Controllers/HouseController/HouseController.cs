using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using CursovaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.HouseController
{
    public class HouseController : Controller
    {
        private readonly IHouse _house;
        private readonly IHouse_Type _house_type;
        private readonly ICity _sity;

        public HouseController(IHouse house)
        {
            _house = house;
        }

        [HttpGet]
        public IActionResult HouseView()
        {
            IEnumerable<House> houses = null;
            houses = _house.GetHouses.OrderBy(i => i.Id);
            var houseObj = new HouseViewModel
            {
                GetHouses = houses
            };
            return View(houseObj);
        }
    }
}