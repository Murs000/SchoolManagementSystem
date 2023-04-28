using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Implimentations
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
            teacherModel.Email = teacher.Email;
            teacherModel.PhoneNumber = teacher.PhoneNumber;
            teacherModel.Subject = teacher.Subject;
            teacherModel.Expirience = teacher.Expirience;
            teacherModel.Position = teacher.Position;

            return teacherModel;
        }

        public Teacher Map(TeacherModel authorModel)
        {
            Teacher teacher = new Teacher();

            teacher.Id = authorModel.Id;
            teacher.Name = authorModel.Name;
            teacher.Surname= authorModel.Surname;
            teacher.BirthDate = authorModel.BirthDate;
            teacher.Gender = authorModel.Gender;
            teacher.Email = authorModel.Email;
            teacher.PhoneNumber = authorModel.PhoneNumber;
            teacher.Subject = authorModel.Subject;
            teacher.Expirience= authorModel.Expirience;
            teacher.Position = authorModel.Position;

            return teacher;
        }
    }
}
