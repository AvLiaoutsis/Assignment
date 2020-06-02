using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Repository.IRepository
{
    public interface IEmployeeSpecialRepository : IRepository<EmployeeSpecial>
    {
        public void Update(EmployeeSpecial employee);

    }
}
