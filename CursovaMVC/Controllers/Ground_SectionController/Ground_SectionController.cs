using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using CursovaMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CursovaMVC.Controllers.Ground_SectionController
{
    public class Ground_SectionController : Controller
    {
        private readonly IGround_Section _ground_section;
        private readonly ICity _sity;

        public Ground_SectionController(IGround_Section ground_Section)
        {
            _ground_section = ground_Section;
        }

        [HttpGet]
        public IActionResult Ground_SectionView()
        {
            IEnumerable<Ground_Section> Ground_Sections = null;
            Ground_Sections = _ground_section.GetGround_Sections.OrderBy(i => i.Id);
            var GSObj = new Ground_SectionViewModel
            {
                GetGround_Sections = Ground_Sections
            };

            return View(GSObj);
        }
    }
}