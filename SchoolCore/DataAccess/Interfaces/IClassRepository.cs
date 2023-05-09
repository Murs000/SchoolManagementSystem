using SchoolCore.Domain.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.DataAccess.Interfaces
{
    public interface IClassRepository
    {
        List<Class> GetAll();
        Class GetById(int id);
        int Insert(Class clas);
        bool Update(Class clas);
    }
}
