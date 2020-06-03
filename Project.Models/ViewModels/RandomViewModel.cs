using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.ViewModels
{
    public class RandomViewModel
    {
        public Guid EmployeeId { get; set; }
        public List<String> AttributeIds {get;set;}
    }
}
