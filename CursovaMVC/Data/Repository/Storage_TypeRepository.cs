using CursovaMVC.Data.EFContext;
using CursovaMVC.Data.Interfaces;
using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Repository
{
    public class Storage_TypeRepository: IStorage_Type
    {
        private readonly EFDBContext _context;
        public Storage_TypeRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Storage_Type> Storage_Types => _context.Storage_Types;
    }
}
