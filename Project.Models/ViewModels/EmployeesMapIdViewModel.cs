using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.ViewModels
{
    public class EmployeesMapIdViewModel
    {
        public IEnumerable<string> EmployeeIds { get; set; }
        public String ChosenId { get; set; }

    }
}
