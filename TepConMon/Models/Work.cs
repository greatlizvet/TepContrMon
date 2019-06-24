using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TepConMon.Models
{
    public class Work
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Наименование деятельности")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }

        public Work()
        {
            Orders = new List<Order>();
            Workers = new List<Worker>();
        }
    }
}