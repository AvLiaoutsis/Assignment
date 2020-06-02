using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAttributeRepository Attribute {get;}
        IEmployeeRepository Employee { get; }
        IEmployeeSpecialRepository EmployeeSpecial { get; }
        IEmployeeAttributeRepository EmployeeAttribute { get; }
        IEmployeeSpecialAttributeRepository EmployeeSpecialAttribute { get; }

        void Save();

    }
}
