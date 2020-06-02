using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.ViewModels
{
    public class AttributesViewModel
    {
        public List<Attribute> MyAttributes { get; set; }
        public List<Attribute> AllAttributes { get; set; }

        public EmployeeSpecial Employee { get; set; }
    }
}
