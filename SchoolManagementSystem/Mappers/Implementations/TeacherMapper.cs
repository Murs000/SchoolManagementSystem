using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Implementations
{
    public class TeacherMapper :ITeacherMapper
    {
        public TeacherModel Map(Teacher teacher)
        {
            TeacherModel teacherModel = new TeacherModel();

            teacherModel.Id = teacher.Id;
            teacherModel.Name = teacher.Name;
            teacherModel.Surname = teacher.Surname;
            teacherModel.FatherName = teacher.FatherName;
            teacherModel.BirthDate = teacher.BirthDate;
            teacherModel.Gender = (Gender)teacher.Gender;
            teacherModel.Email = teacher.Email;
            teacherModel.PhoneNumber = teacher.PhoneNumber;
            teacherModel.Subject = (Subject)teacher.Subject;
            teacherModel.Expirience = teacher.Expirience;
            teacherModel.Position = (Position)teacher.Position;

            return teacherModel;
        }

        public Teacher Map(TeacherModel teacherModel)
        {
            Teacher teacher = new Teacher();

            teacher.Id = teacherModel.Id;
            teacher.Name = teacherModel.Name;
            teacher.Surname= teacherModel.Surname;
            teacher.FatherName = teacherModel.FatherName;
            teacher.BirthDate = teacherModel.BirthDate;
            teacher.Gender = (byte)teacherModel.Gender;
            teacher.Email = teacherModel.Email;
            teacher.PhoneNumber = teacherModel.PhoneNumber;
            teacher.Subject = (byte)teacherModel.Subject;
            teacher.Expirience= teacherModel.Expirience;
            teacher.Position = (byte)teacherModel.Position;

            return teacher;
        }
    }
}
