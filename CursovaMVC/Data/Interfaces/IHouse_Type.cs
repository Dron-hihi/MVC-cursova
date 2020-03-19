using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Interfaces
{
    public interface IHouse_Type
    {
        IEnumerable<House_Type> house_Types { get; }
    }
}
