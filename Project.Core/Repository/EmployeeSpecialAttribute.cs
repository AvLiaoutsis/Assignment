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
    public class EmployeeSpecialAttributeRepository : Repository<EmployeeSpecialAttribute>, IEmployeeSpecialAttributeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeSpecialAttributeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
