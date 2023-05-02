using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Mappers.Implimentations;
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

        public List<StudentModel> GetAll()
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            List<Student> students = _db.StudentRepository.GetAll();

            int no = 1;

            foreach (var student in students)
            {
                StudentModel studentModel = _studentMapper.Map(student);

                studentModel.No = no++;

                studentModels.Add(studentModel);
            }

            return studentModels;
        }

        public int Save(StudentModel studentModel)
        {
            Student willSavedStudent = _studentMapper.Map(studentModel);

            willSavedStudent.Modifier = new User { Id = 1 };
            willSavedStudent.ModifiedDate = DateTime.Now;

            if (willSavedStudent.Id == 0)
            {
                willSavedStudent.CreationDate = DateTime.Now;
                willSavedStudent.Creator = new User() { Id = 1 };

                return _db.StudentRepository.Insert(willSavedStudent);
            }
            else
            {
                var existingAuthor = _db.StudentRepository.GetById(studentModel.Id);

                willSavedStudent.CreationDate = existingAuthor.CreationDate;
                willSavedStudent.Creator = existingAuthor.Creator;

                _db.StudentRepository.Update(willSavedStudent);

                return willSavedStudent.Id;
            }
        }

        public bool Delete(int id)
        {
            Student student = _db.StudentRepository.GetById(id);

            student.IsDeleted = true;
            student.ModifiedDate = DateTime.Now;
            student.Modifier = new User { Id = 1 };

            return _db.StudentRepository.Update(student);
        }



    }
}
