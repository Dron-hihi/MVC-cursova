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

        public ApartmentController(IApartment apartment, IHouse_Type house_Type)
        {
            _apartment = apartment;
            _house_type = house_Type;
        }
        
        [Route("Apartment/ApartmentView")]
        [Route("Apartment/ApartmentView/{house_Type}")]
        public ViewResult ApartmentView(string category)
        {
            IEnumerable<Apartment> apartments = null;
            string aptype = "";

            if (string.IsNullOrEmpty(category))
            {
                apartments = _apartment.GetApartments.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("Цегла", category, StringComparison.OrdinalIgnoreCase))
                {
                    apartments = _apartment.GetApartments.Where(x => x.House_Type.Name.Equals("Цегла"));
                }
                else if (string.Equals("Панель", category, StringComparison.OrdinalIgnoreCase))
                {
                    apartments = _apartment.GetApartments.Where(x => x.House_Type.Name.Equals("Панель"));
                }
                else if (string.Equals("Моноліт", category, StringComparison.OrdinalIgnoreCase))
                {
                    apartments = _apartment.GetApartments.Where(x => x.House_Type.Name.Equals("Моноліт"));
                }
                else if (string.Equals("Піноблок", category, StringComparison.OrdinalIgnoreCase))
                {
                    apartments = _apartment.GetApartments.Where(x => x.House_Type.Id.Equals("Піноблок"));
                }
                aptype = category;
            }

            var tmp = _house_type.house_Types;

            var apartObj = new ApartmentViewModel
            {
                GetApartments = apartments,
                HouseType = aptype,
                TypeHouse = tmp
            };

            return View(apartObj);
        }
    }
}
