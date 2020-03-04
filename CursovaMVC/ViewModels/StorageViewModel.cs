using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.ViewModels
{
    public class StorageViewModel
    {
        public IEnumerable<Storage> GetStorages { get; set; }
        public IEnumerable<Storage> GetStType { get; set; }
        public IEnumerable<Storage> GetStSity { get; set; }
    }
}
