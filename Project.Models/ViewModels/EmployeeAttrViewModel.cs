﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.ViewModels
{
    public class EmployeeAttrViewModel
    {
        public EmployeeSpecial Employee { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
