using CursovaMVC.Data.EFContext;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Repository
{
    public class House_TypeRepository: IHouse_Type
    {
        private readonly EFDBContext _context;
        public House_TypeRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<House_Type> house_Types => _context.House_Types.OrderBy(x => x.Name);

    }
}
