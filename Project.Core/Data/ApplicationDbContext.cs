using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Attribute = Project.Models.Attribute;

namespace Project.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttribute> EmployeeAttribute { get; set; }

    }
}
