using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TepConMon.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "ФИО")]
        public string Name { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }

        public virtual ICollection<Work> Works { get; set; }

        public Worker()
        {
            Works = new List<Work>();
        }
    }
}