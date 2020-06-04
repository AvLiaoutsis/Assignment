using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Models
{
    public class EmployeeSpecial
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public bool HasCar { get; set; }
        public string StreetAddress { get; set; }
        public List<EmployeeAttribute> ListAttributes {get;set;}

    }
}
