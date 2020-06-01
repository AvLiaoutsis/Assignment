using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employee employee)
        {
            var objFromDb = _db.Employee.FirstOrDefault(s => s.EMP_ID == employee.EMP_ID);

            if (objFromDb != null)
            {
                objFromDb.EMP_Name = employee.EMP_Name;
                objFromDb.EMP_DateOfHire = employee.EMP_DateOfHire;
                objFromDb.EMP_Supervisor = employee.EMP_Supervisor;
            }
        }

        public void Update(EmployeeSpecial employee)
        {
            var objFromDb = _db.EmployeeSpecials.FirstOrDefault(s => s.Id == employee.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = employee.Name;
                objFromDb.HasCar = employee.HasCar;
                employee.StreetAddress = employee.StreetAddress;
                employee.BirthDate = employee.BirthDate;
                employee.ListAttributes = employee.ListAttributes;
            }
        }
    }
}
