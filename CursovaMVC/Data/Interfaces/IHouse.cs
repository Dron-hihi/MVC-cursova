using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Interfaces
{
    public interface IHouse
    {
        IEnumerable<House> GetHouses { get; }
        IEnumerable<House> GetHouseTypes { get; }
        IEnumerable<House> GetHouseSitys { get; }

        House GetHouse(int HouseId);
        House GetHouseType(int HouseType);
        House GetHouseSity(int HouseSity);
    }
}
