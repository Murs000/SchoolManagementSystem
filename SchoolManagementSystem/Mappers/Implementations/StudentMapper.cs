
using SchoolCore.Domain.Entities.Implimentations;
using SchoolCore.Domain.Enums;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Implementations
{
    public class StudentMapper : IStudentMapper
    {
        public StudentModel Map(Student student)
        {
            StudentModel studentmodel = new StudentModel();

            studentmodel.Id = student.Id;
            studentmodel.Name = student.Name;
            studentmodel.Surname = student.Surname;
            studentmodel.FatherName = student.FatherName;
            studentmodel.BirthDate = student.BirthDate;
            studentmodel.Gender = (Gender)student.Gender;
            studentmodel.Email = student.Email;
            studentmodel.PhoneNumber = student.PhoneNumber;
            


            return studentmodel;
        }

        public Student Map(StudentModel studentModel)
        {
            Student student = new Student();

            student.Id = studentModel.Id;
            student.Name = studentModel.Name;
            student.Surname = studentModel.Surname;
            student.BirthDate = studentModel.BirthDate;
            student.Gender = studentModel.Gender;
            student.Email = studentModel.Email;
            student.PhoneNumber = studentModel.PhoneNumber;
 
            return student;
        }

    }
}
