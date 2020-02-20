using CursovaMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Interfaces
{
    public interface IStorage
    {
        IEnumerable<Storage> GetStorages { get; }
        IEnumerable<Storage> GetStoragesSity { get; }
        IEnumerable<Storage> GetStoragesType { get; }

        Storage GetStorage(int StorageId);
        Storage GetStorageSity(int StorageId);
        Storage GetStorageType(int StorageId);
    }
}
