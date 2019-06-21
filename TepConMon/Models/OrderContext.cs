using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TepConMon.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Zakazchik> Zakazchiks { get; set; }
    }
}