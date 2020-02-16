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
    public class OfficeRepository: IOffice
    {
        private readonly EFDBContext _context;
        public OfficeRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Office> GetOffices => _context.Offices;
        public IEnumerable<Office> GetOfficesSity => _context.Offices.Include(x => x.O_SityId);

        public Office GetOffice(int OffiseId) => _context.Offices.FirstOrDefault();
        public Office GetOfficeSity(int OfficeId) => _context.Offices.FirstOrDefault(x => x.Id == OfficeId);
    }
}
