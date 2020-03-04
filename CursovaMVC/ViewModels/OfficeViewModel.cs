using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.ViewModels
{
    public class OfficeViewModel
    {
        public IEnumerable<Office> GetOffices { get; set; }
        public IEnumerable<Office> GetOfSity { get; set; }
    }
}
