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
        public IEnumerable<Apartment> GetApType { get; set; }
        public IEnumerable<Apartment> GetApSity { get; set; }
    }
}
