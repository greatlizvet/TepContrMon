using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TepConMon.Models
{
    public class Material
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        public double Cost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Material()
        {
            Orders = new List<Order>();
        }
    }
}