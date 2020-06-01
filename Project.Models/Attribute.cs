using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Attribute
    {
        [Key]
        public Guid ATTR_ID { get; set; }

        [Display(Name ="Name")]
        public string ATTR_Name { get; set; }
        [Display(Name = "Value")]
        public string ATTR_Value { get; set; }

    }
}
