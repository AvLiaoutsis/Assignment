using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.ViewModels
{
    public class EmployeesMapViewModel
    {
        public IEnumerable<EmployeeSpecial> OtherEmloyees { get; set; }
        public EmployeeSpecial ChosenEmployee { get; set; }

    }
}
