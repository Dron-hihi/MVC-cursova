using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursovaMVC.Models;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.ViewModels;

namespace CursovaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApartment _apartment;
        private readonly IHouse _house;
        private readonly IOffice _office;
        private readonly IStorage _storage;
        private readonly IGround_Section _ground_Section;
        private readonly ICity _sity;
        private readonly IHouse_Type _house_Type;
        private readonly IStorage_Type _storage_Type;

        public HomeController(IApartment apartment, IHouse house, IOffice office, IStorage storage, IGround_Section ground_Section, ICity sity, IHouse_Type house_Type, IStorage_Type storage_Type)
        {
            _apartment = apartment;
            _house = house;
            _office = office;
            _storage = storage;
            _ground_Section = ground_Section;
            _sity = sity;
            _house_Type = house_Type;
            _storage_Type = storage_Type;
        }
        public ViewResult Index()
        {
            //var GetA = _apartment.GetApartments;
            //var GetH = _house.GetHouses;
            //var GetO = _office.GetOffices;
            //var GetS = _storage.GetStorages;

            //var info = new HomeViewModel
            //{
            //    GetApartments=GetA,
            //    GetHouses = GetH,
            //    GetOffices= GetO,
            //    GetStorages=GetS
            //};
            //return View(info);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
