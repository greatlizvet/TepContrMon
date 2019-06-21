using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TepConMon.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}