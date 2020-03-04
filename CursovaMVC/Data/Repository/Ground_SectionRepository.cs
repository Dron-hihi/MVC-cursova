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
    public class Ground_SectionRepository: IGround_Section
    {
        private readonly EFDBContext _context;
        public Ground_SectionRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Ground_Section> GetGround_Sections => _context.Ground_Sections;
        public IEnumerable<Ground_Section> GetGround_SectionsSity => _context.Ground_Sections.Include(x => x.GS_SityId);

        public Ground_Section GetGround_Section(int Ground_SectionId) => _context.Ground_Sections.FirstOrDefault();
        public Ground_Section GetGround_SectionSity(int Ground_SectionId) => _context.Ground_Sections.FirstOrDefault(x => x.Id == Ground_SectionId);
    }
}




