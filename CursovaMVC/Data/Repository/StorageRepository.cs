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
    public class StorageRepository: IStorage
    {
        private readonly EFDBContext _context;
        public StorageRepository(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Storage> GetStorages => _context.Storages;
        public IEnumerable<Storage> GetStoragesSity => _context.Storages.Include(x => x.SityId);
        public IEnumerable<Storage> GetStoragesType => _context.Storages.Include(x => x.StorageTypeId);

        public Storage GetStorage(int StorageId) => _context.Storages.FirstOrDefault();
        public Storage GetStorageSity(int StorageId) => _context.Storages.FirstOrDefault(x => x.Id == StorageId);
        public Storage GetStorageType(int StorageId) => _context.Storages.FirstOrDefault(x => x.Id == StorageId);
    }
}
