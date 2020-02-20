using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Apartment> GetApartments { get; set; }
        public IEnumerable<Apartment> GetApType { get; set; }
        public IEnumerable<Apartment> GetApSity { get; set; }

        public IEnumerable<House> GetHouses { get; set; }
        public IEnumerable<House> GetHoType { get; set; }
        public IEnumerable<House> GetHoSity { get; set; }

        public IEnumerable<Office> GetOffices { get; set; }
        public IEnumerable<Office> GetOfSity { get; set; }

        public IEnumerable<Storage> GetStorages { get; set; }
        public IEnumerable<Storage> GetStType { get; set; }
        public IEnumerable<Storage> GetStSity { get; set; }
    }
}
