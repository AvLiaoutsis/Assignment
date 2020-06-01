using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attribute = Project.Models.Attribute;


namespace Project.DataAccess.Repository
{
    public class AttributeRepository : Repository<Attribute>, IAttributeRepository
    {
        private readonly ApplicationDbContext _db;

        public AttributeRepository(ApplicationDbContext db) : base(db)
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

            var associationAttributes = _db.EmployeeAttribute.Where(s => s.EMPATTR_AttributeID == id);

            _db.RemoveRange(associationAttributes);

            _db.Remove(objFromDb);


        }
    }
}
