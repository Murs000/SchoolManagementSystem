using SchoolCore.DataAccess.Interfaces;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Implimentations
{
    internal class StudentService : IStudentService
    {
        private readonly IUnitOfWork _db;
        private readonly IStudentMapper _studentMapper;
        public StudentService(IUnitOfWork db, IStudentMapper studentMapper)
        {
            _db = db;
            _studentMapper = studentMapper;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeacherModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(StudentModel studentModel)
        {
            throw new NotImplementedException();
        }

        public int Save(StudentModel studentModel)
        {
            throw new NotImplementedException();
        }

        List<StudentModel> IStudentService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
