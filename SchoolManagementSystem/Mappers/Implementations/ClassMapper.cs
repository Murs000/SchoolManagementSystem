
using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Implementations
{
    internal class ClassMapper : IClassMapper
    {
        private readonly ITeacherMapper _teacherMapper;
        public ClassMapper(ITeacherMapper teacherMapper)
        {
            _teacherMapper = teacherMapper;
        }

        public ClassModel Map(Class classEntity)
        {
            ClassModel model = new ClassModel();

            model.Name = classEntity.Name;
            model.Grade = classEntity.Grade;
            model.Teacher = _teacherMapper.Map(classEntity.Teacher);

            return model;
        }

        public Class Map(ClassModel classModel)
        {
            Class classEntity = new Class();

            classEntity.Name = classModel.Name;
            classEntity.Grade = classModel.Grade;
            classEntity.Teacher = _teacherMapper.Map(classModel.Teacher);
            
            return classEntity;
        }
    }
}
