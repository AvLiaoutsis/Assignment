using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Repository
{
    public class AttributeRepository : Repository<Attribute>, IAttributeRepository
    {
        private readonly ApplicationDbContext _db;

        public AttributeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Attribute Attribute)
        {

        }
    }
}
