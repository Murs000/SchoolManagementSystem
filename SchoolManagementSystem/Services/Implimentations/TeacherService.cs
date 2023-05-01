using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
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
    internal class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _db;
        private readonly ITeacherMapper _teacherMapper;
        public TeacherService(IUnitOfWork db, ITeacherMapper teacherMapper)
        {
            _db = db;
            _teacherMapper = teacherMapper;
        }
        public List<TeacherModel> GetAll()
        {
            List<TeacherModel> teacherModels = new List<TeacherModel>();
            List<Teacher> teachers = _db.TeacherRepository.GetAll();

            int no = 1;

            foreach (var teacher in teachers)
            {
                TeacherModel teacherModel = _teacherMapper.Map(teacher);

                teacherModel.No = no++;

                teacherModels.Add(teacherModel);
            }

            return teacherModels;
        }

        public int Save(TeacherModel teacherModel)
        {
            Teacher willSavedTeacher = _teacherMapper.Map(teacherModel);

            willSavedTeacher.Modifier = new User { Id = 1 };
            willSavedTeacher.ModifiedDate = DateTime.Now;

            if (willSavedTeacher.Id == 0)
            {
                willSavedTeacher.CreationDate = DateTime.Now;
                willSavedTeacher.Creator = new User() { Id = 1 };

                return _db.TeacherRepository.Insert(willSavedTeacher);
            }
            else
            {
                var existingAuthor = _db.TeacherRepository.GetById(teacherModel.Id);

                willSavedTeacher.CreationDate = existingAuthor.CreationDate;
                willSavedTeacher.Creator = existingAuthor.Creator;

                _db.TeacherRepository.Update(willSavedTeacher);

                return willSavedTeacher.Id;
            }
        }

        public bool Delete(int id)
        {
            Teacher teacher = _db.TeacherRepository.GetById(id);

            teacher.IsDeleted = true;
            teacher.ModifiedDate = DateTime.Now;
            teacher.Modifier = new User { Id = 1 };

            return _db.TeacherRepository.Update(teacher);
        }
    }
}
