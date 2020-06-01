using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public void Update(Employee employee);

    }
}
