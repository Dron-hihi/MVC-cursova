using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Models
{
    /// <summary>
    /// Квартири
    /// </summary>
    public class Apartment
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Імя квартири
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Зображення квартири
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Кількість кімнат
        /// </summary>
        public int Rooms { get; set; }
        /// <summary>
        /// Площа загальна
        /// </summary>
        public double Total_Area { get; set; }
        /// <summary>
        /// Площа жила
        /// </summary>
        public double Area_Lived { get; set; }
        /// <summary>
        /// Ремонт? так/ні
        /// </summary>
        public bool Repair { get; set; }
        /// <summary>
        /// Будівництво завершене? так/ні
        /// </summary>
        public bool Built_isCompleted { get; set; }
        /// <summary>
        /// поверх розміщення квартири
        /// </summary>
        public int Floor { get; set; }
        /// <summary>
        /// Здача в оренду? так/ні
        /// </summary>
        public bool Rent { get; set; }
        /// <summary>
        /// Ціна квартири
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// ID->House_Type Типу будинку 
        /// </summary>
        [ForeignKey("House_Type")]
        public int A_HouseTypeId { get; set; }
        /// <summary>
        /// ID->Sity Місто
        /// </summary>
        [ForeignKey("Sity")]
        public int A_SityId { get; set; }

        public virtual House_Type House_Type { get; set; }
        public virtual Sity Sity { get; set; }

    }
}
