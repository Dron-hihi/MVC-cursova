using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.ViewModels
{
    public class ApartmentViewModel
    {
        public IEnumerable<Apartment> GetApartments { get; set; }

        public string HouseType { get; set; }
        public IEnumerable<House_Type> TypeHouse { get; set; }
    }
}
