using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TepConMon.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}