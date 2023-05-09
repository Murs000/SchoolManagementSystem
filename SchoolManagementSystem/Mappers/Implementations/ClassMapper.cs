using SchoolCore.Domain.Entities.Implementations;
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
        public ClassModel Map(Class clas)
        {
            ClassModel model = new ClassModel();
            model.Name = clas.Name;
            model.Grade = clas.Grade;
            model.Teacher = clas.Teacher;
            return model;
        }

        public Class Map(ClassModel classModel)
        {
            Class clas = new Class();
            clas.Name = classModel.Name;
            clas.Grade = classModel.Grade;
            clas.Teacher = classModel.Teacher;
            return clas;
        }
    }
}
