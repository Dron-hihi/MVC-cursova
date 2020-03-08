using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using CursovaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.StorageController
{
    public class StorageController : Controller
    {
        private readonly IStorage _storage;
        private readonly IStorage_Type _storage_type;
        private readonly ICity _sity;

        public StorageController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public IActionResult StorageView()
        {
            IEnumerable<Storage> storages = null;
            storages = _storage.GetStorages.OrderBy(i => i.Id);
            var storObj = new StorageViewModel
            {
                GetStorages = storages
            };
            return View(storObj);
        }
    }
}