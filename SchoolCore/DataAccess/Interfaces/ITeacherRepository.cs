using SchoolCore.Domain.Entities.Implimentations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.DataAccess.Interfaces
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAll();
        Teacher GetById(int id);
        int Insert(Teacher teacher);
        bool Update(Teacher teacher);
    }
}
