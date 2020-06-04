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

        public DbSet<EmployeeSpecial> EmployeeSpecial { get; set; }

        public DbSet<EmployeeSpecialAttribute> EmployeeSpecialAttribute { get; set; }

        public DbSet<EmployeeAttribute> EmployeeAttribute { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAttribute>()
                .HasKey(a => new { a.EMPATTR_AttributeID, a.EMPATTR_EmployeeID });

            modelBuilder.Entity<Attribute>()
                .HasKey(a => a.ATTR_ID );

            modelBuilder.Entity<Employee>()
                .HasKey(a => a.EMP_ID);

            modelBuilder.Entity<EmployeeSpecial>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<EmployeeSpecialAttribute>()
                .HasKey(a => new { a.AttributeId, a.EmployeeId });
        }

    }
}
