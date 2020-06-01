using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public Guid EMP_ID { get; set; }
        public string EMP_Name { get; set; }
        public DateTime EMP_DateOfHire { get; set; }
        public Employee EMP_Supervisor { get; set; }
    }
}
