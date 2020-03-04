using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Interfaces
{
    public interface IGround_Section
    {
        IEnumerable<Ground_Section> GetGround_Sections { get; }
        IEnumerable<Ground_Section> GetGround_SectionsSity { get; }

        Ground_Section GetGround_Section(int Ground_sectionId);
        Ground_Section GetGround_SectionSity(int Ground_sectionSity);
    }
}
