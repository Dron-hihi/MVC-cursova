using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Interfaces
{
    public interface IApartment
    {
        IEnumerable<Apartment> GetApartments { get; }
        Apartment GetApartment(int Id);
    }
}
