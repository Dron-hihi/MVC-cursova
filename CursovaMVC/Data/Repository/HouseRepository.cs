using CursovaMVC.Data.EFContext;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Repository
{
    public class HouseRepository: IHouse
    {
        private readonly EFDBContext _context;
        public HouseRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<House> GetHouses => _context.Houses;
        public IEnumerable<House> GetHouseTypes => _context.Houses.Include(x => x.H_HouseTypeId);
        public IEnumerable<House> GetHouseSitys => _context.Houses.Include(x => x.H_SityId);

        public House GetHouse(int HouseId) => _context.Houses.FirstOrDefault();
        public House GetHouseType(int HouseType) => _context.Houses.FirstOrDefault(x => x.H_HouseTypeId == HouseType);
        public House GetHouseSity(int HouseSity) => _context.Houses.FirstOrDefault(x => x.H_SityId == HouseSity);
    }
}
