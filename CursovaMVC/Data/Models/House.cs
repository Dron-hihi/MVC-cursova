using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Models
{
    public class House
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Кількість кімнат
        /// </summary>
        public int Rooms { get; set; }
        /// <summary>
        /// Площа загальна
        /// </summary>
        public int Total_Area { get; set; }
        /// <summary>
        /// Площа жила
        /// </summary>
        public int Area_Lived { get; set; }
        /// <summary>
        /// Ремонт? так/ні
        /// </summary>
        public bool Repair { get; set; }
        /// <summary>
        /// Будівництво завершене? так/ні
        /// </summary>
        public bool Built_isCompleted { get; set; }
        /// <summary>
        /// ID->House_Type Типу будинку 
        /// </summary>
        public int H_HouseTypeId { get; set; }
        /// <summary>
        /// ID->Sity Місто
        /// </summary>
        public int H_SityId { get; set; }

        public virtual House_Type House_Type { get; set; }
        public virtual Sity Sity { get; set; }
    }
}
