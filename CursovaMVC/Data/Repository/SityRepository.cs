using CursovaMVC.Data.EFContext;
using CursovaMVC.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Repository
{
    public class SityRepository : ICity
    {
        private readonly EFDBContext _context;
        public SityRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<City> Sities => _context.Sities;
    }
}
