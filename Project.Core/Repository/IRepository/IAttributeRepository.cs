using System;
using System.Collections.Generic;
using System.Text;
using Attribute = Project.Models.Attribute;


namespace Project.DataAccess.Repository.IRepository
{
    public interface IAttributeRepository : IRepository<Attribute>
    {
        public void Update(Attribute attribute);
        public Attribute Get(string name, string value);

    }
}
