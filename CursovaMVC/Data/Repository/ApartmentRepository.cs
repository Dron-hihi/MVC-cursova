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
    public class ApartmentRepository : IApartment
    {
        private readonly EFDBContext _context;
        public ApartmentRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Apartment> GetApartments => _context.Apartments;
        public IEnumerable<Apartment> GetApartmentsType => _context.Apartments.Include(x => x.A_HouseTypeId);
        public IEnumerable<Apartment> GetApartmentsSity => _context.Apartments.Include(x => x.A_SityId);

        public Apartment GetApartment(int ApartmentId) => _context.Apartments.FirstOrDefault();
        public Apartment GetApartmentType(int ApartmentType) => _context.Apartments.FirstOrDefault(x => x.A_HouseTypeId == ApartmentType);
        public Apartment GetApartmentSity(int ApartmentSity) => _context.Apartments.FirstOrDefault(x => x.A_SityId == ApartmentSity);
    }
}
