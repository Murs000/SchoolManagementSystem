using SchoolCore.Domain.Entities.Implimentations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.DataAccess.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        int Insert(Student student);
        bool Update(Student student);
        //bool Delete(int id);
    }
}
