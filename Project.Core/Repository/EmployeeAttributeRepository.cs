using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attribute = Project.Models.Attribute;


namespace Project.DataAccess.Repository
{
    public class EmployeeAttributeRepository : Repository<EmployeeAttribute>, IEmployeeAttributeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeAttributeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Attribute attribute)
        {
            var objFromDb = _db.Attribute.FirstOrDefault(s => s.ATTR_ID == attribute.ATTR_ID);

            if (objFromDb != null)
            {
                objFromDb.ATTR_Name = attribute.ATTR_Name;
                objFromDb.ATTR_Value = attribute.ATTR_Value;

            }
        }

        public void Delete(Guid id)
        {
            var objFromDb = _db.Attribute.SingleOrDefault(s => s.ATTR_ID == id);

            var associationAttributes = _db.EmployeeAttribute.Where(s => s.EMPATTR_AttributeID == id).ToList();

            _db.RemoveRange(associationAttributes);

            _db.Remove(objFromDb);


        }

        public Attribute Get(string name, string value)
        {
            var objFromDb = _db.Attribute.SingleOrDefault(s=>s.ATTR_Name.Contains(name) && s.ATTR_Value.Contains(value));

            return objFromDb;
        }
    }
}
