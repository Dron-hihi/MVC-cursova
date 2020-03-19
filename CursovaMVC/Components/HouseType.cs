using CursovaMVC.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Components
{
    public class HouseType : ViewComponent
    {
        private readonly IHouse_Type _house_type;
        public HouseType(IHouse_Type house_Type)
        {
            _house_type = house_Type;
        }

        public IViewComponentResult Invoke()
        {
            var hoty = _house_type.house_Types;
            return View(hoty);
        }
    }
}
