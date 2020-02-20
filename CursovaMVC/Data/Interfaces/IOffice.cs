using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Interfaces
{
    public interface IOffice
    {
        IEnumerable<Office> GetOffices { get; }
        IEnumerable<Office> GetOfficesSity { get; }

        Office GetOffice(int OffiseId);
        Office GetOfficeSity(int OfficeId);
    }
}
