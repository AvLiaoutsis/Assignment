using Project.DataAccess.Data;
using Project.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IAttributeRepository Attribute { get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Attribute = new AttributeRepository(_db);
            Employee = new EmployeeRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
