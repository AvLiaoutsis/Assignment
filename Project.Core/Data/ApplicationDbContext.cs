using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Attribute = Project.Models.Attribute;

namespace Project.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }

        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSpecial> EmployeeSpecials { get; set; }

        public DbSet<EmployeeAttribute> EmployeeAttribute { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAttribute>()
                .HasKey(a => new { a.EMPATTR_AttributeID, a.EMPATTR_EmployeeID });
        }

    }
}
