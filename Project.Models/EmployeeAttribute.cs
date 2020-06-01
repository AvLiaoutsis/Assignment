using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class EmployeeAttribute
    {
        public Guid EMPATTR_EmployeeID { get; set; }
        public Guid EMPATTR_AttributeID { get; set; }
    }
}
