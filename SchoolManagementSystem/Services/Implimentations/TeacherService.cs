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
    internal class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _db;
        private readonly ITeacherMapper _teacherMapper;
        public TeacherService(IUnitOfWork db, ITeacherMapper teacherMapper)
        {
            _db = db;
            _teacherMapper = teacherMapper;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeacherModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(TeacherModel teacherModel)
        {
            throw new NotImplementedException();
        }

        public int Save(TeacherModel teacherModel)
        {
            throw new NotImplementedException();
        }
    }
}
