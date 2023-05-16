//using SchoolCore.Domain.Entities.Implementations;
//using SchoolManagementSystem.Mappers.Interfaces;
//using SchoolManagementSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolManagementSystem.Mappers.Implementations
//{
//    public class MarkMapper : IMarkMapper
//    {
//        private readonly IStudentMapper _studentMapper;
//        private readonly ITeacherMapper _teacherMapper;

//        public MarkMapper(IStudentMapper studentMapper,ITeacherMapper teacherMapper)
//        {
//            _studentMapper = studentMapper;
//            _teacherMapper = teacherMapper;
//        }



//        public MarkModel Map(Mark markEntity)
//        {
//            MarkModel model = new MarkModel();

//            model.Id = markEntity.Id;
//            model.Student = _studentMapper.Map(markEntity.Student);
//            model.Teacher = _teacherMapper.Map(markEntity.Teacher);
//            model.ExamType = markEntity.ExamType;
//            model.MarkEnum = markEntity.MarkEnum;


//            return model;
//        }

//        public Mark Map(MarkModel markModel)
//        {
//            Mark markEntity = new Mark();

//            markEntity.Id = markModel.Id;
//            markEntity.Student = _studentMapper.Map(markModel.Student);
//            markEntity.Teacher = _teacherMapper.Map(markModel.Teacher);
//            markEntity.ExamType = markModel.ExamType;
//            markEntity.MarkEnum = markModel.MarkEnum;


//            return markEntity;
//        }
//    }
//}
