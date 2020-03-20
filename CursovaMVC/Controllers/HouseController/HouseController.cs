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

        public HouseController(IHouse house, IHouse_Type house_Type)
        {
            _house = house;
            _house_type = house_Type;
        }
        //[HttpPost]
        [Route("House/HouseView")]
        [Route("House/HouseView/{category}")]
        public ViewResult HouseView(string category)
        {
            IEnumerable<House> houses = null;
            string houseType = "";
            if (string.IsNullOrEmpty(category))
            {
                houses = _house.GetHouses.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("Цегла", category, StringComparison.OrdinalIgnoreCase))
                {
                    houses = _house.GetHouses.Where(x => x.House_Type.Name.Equals("Цегла"));
                }
                else if (string.Equals("Панель", category, StringComparison.OrdinalIgnoreCase))
                {
                    houses = _house.GetHouses.Where(x => x.House_Type.Name.Equals("Панель"));
                }
                else if (string.Equals("Моноліт", category, StringComparison.OrdinalIgnoreCase))
                {
                    houses = _house.GetHouses.Where(x => x.House_Type.Name.Equals("Моноліт"));
                }
                else if (string.Equals("Піноблок", category, StringComparison.OrdinalIgnoreCase))
                {
                    houses = _house.GetHouses.Where(x => x.House_Type.Id.Equals("Піноблок"));
                }
                houseType = category;
            }

            var tmp = _house_type.house_Types;

            var apartObj = new HouseViewModel
            {
                GetHouses = houses,
                HouseType = houseType,
                TypeHouse = tmp
            };

            return View(apartObj);
        }
    }
}