using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.StorageController
{
    public class StorageController : Controller
    {
        private readonly IStorage _storage;
        private readonly IStorage_Type _storage_type;
        private readonly ICity _sity;

        [HttpGet]
        public IActionResult StorageView()
        {
            return View();
        }
    }
}