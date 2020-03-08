using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursovaMVC.Data.Models
{
    public class Office
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Назва офісу
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Зображення офісу
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Площа складу
        /// </summary>
        public double Total_Area { get; set; }
        /// <summary>
        /// поверх
        /// </summary>
        public int Floor { get; set; }
        /// <summary>
        /// Ціна оренди офісу
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// ID->Sity Місто
        /// </summary>
        [ForeignKey("Sity")]
        public int O_SityId { get; set; }

        public virtual City Sity { get; set; }
    }
}
