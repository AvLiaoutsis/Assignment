using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.Models
{
    public class EmployeeSpecialAttribute
    {
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public EmployeeSpecial Employee { get; set; }

        public Guid AttributeId { get; set; }

        [ForeignKey("AttributeId")]

        public Attribute Attribute { get; set; }
    }
}
