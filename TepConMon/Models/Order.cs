using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TepConMon.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Номер заказа")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Заказчик")]
        public int ZakazchikId { get; set; }

        //список материалов для заказа
        public virtual ICollection<Material> Materials { get; set; }
        //список работ для заказа
        public virtual ICollection<Work> Works { get; set; }
        //поле навигации с заказчиком
        public virtual Zakazchik Zakazchik { get; set; }

        public Order()
        {
            Materials = new List<Material>();
            Works = new List<Work>();
        }
    }
}