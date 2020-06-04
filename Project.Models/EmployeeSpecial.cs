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

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Car Availability")]

        public bool HasCar { get; set; }
        [Display(Name = "Street Address")]

        public string StreetAddress { get; set; }
        public List<EmployeeAttribute> ListAttributes { get; set; }

    }
}
