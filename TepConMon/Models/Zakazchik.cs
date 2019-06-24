using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TepConMon.Models
{
    public class Zakazchik
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название организации")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Юридический адрес организации")]
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Zakazchik()
        {
            Orders = new List<Order>();
        }
    }
}