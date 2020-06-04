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
                objFromDb.StreetAddress = employee.StreetAddress;
                objFromDb.BirthDate = employee.BirthDate;
                objFromDb.ListAttributes = employee.ListAttributes;
            }
        }

        public void Delete(Guid id)
        {
            var objFromDb = _db.EmployeeSpecial.SingleOrDefault(s => s.Id == id);

            var associationAttributes = _db.EmployeeSpecialAttribute.Where(s => s.EmployeeId == id).ToList();

            if (associationAttributes.Any())
            {
                _db.RemoveRange(associationAttributes);

            }

            _db.Remove(objFromDb);


        }
    }
}
