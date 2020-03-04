using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.ViewModels
{
    public class HouseViewModel
    {
        public IEnumerable<House> GetHouses { get; set; }
        public IEnumerable<House> GetHoType { get; set; }
        public IEnumerable<House> GetHoSity { get; set; }
    }
}
