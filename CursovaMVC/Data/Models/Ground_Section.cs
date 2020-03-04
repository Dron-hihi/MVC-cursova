using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Models
{
    public class Ground_Section
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Імя ділянки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Зображення ділянки
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Площа
        /// </summary>
        public double Area { get; set; }
        /// <summary>
        /// Ціна ділянки
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// ID->Sity Місто
        /// </summary>
        [ForeignKey("Sity")]
        public int GS_SityId { get; set; }

        public virtual City Sity { get; set; }
    }
}
