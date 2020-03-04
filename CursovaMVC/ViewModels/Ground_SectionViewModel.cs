using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.ViewModels
{
    public class Ground_SectionViewModel
    {
        public IEnumerable<Ground_Section> GetGround_Sections { get; set; }
        public IEnumerable<Ground_Section> GetGround_SectionsSity { get; set; }
    }
}
