using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.DataAccess.Repository
{
    public class EmployeeSpecialRepository : Repository<EmployeeSpecial>, IEmployeeSpecialRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeSpecialRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(EmployeeSpecial employee)
        {
            var objFromDb = _db.EmployeeSpecial.FirstOrDefault(s => s.Id == employee.Id);

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
