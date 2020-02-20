using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Models
{
    /// <summary>
    /// Складські приміщення
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Назва складу
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Площа складу
        /// </summary>
        public double Total_Area { get; set; }
        /// <summary>
        /// Ціна оренди складу
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Тип складу
        /// </summary>
        [ForeignKey("Storage_Type")]
        public int StorageTypeId { get; set; }
        /// <summary>
        /// ID->Sity Місто
        /// </summary>
        [ForeignKey("Sity")]
        public int SityId { get; set; }

        public virtual Storage_Type Storage_Type { get; set; }
        public virtual City Sity { get; set; }


    }
}
