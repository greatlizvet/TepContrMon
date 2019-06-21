using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TepConMon.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ZakazchikId { get; set; }

        //список материалов для заказа
        public virtual ICollection<Material> Materials { get; set; }
        //список работ для заказа
        public virtual ICollection<Work> Works { get; set; }
        //поле навигации с заказчиком
        public virtual Zakazchik Zakazchik { get; set; }
    }
}