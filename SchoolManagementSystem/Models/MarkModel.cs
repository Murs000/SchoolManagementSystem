using DocumentFormat.OpenXml.Wordprocessing;
using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    internal class MarkModel
    {
        public int No { get; set; }
        public int Id { get; set; }
        public StudentModel Student { get; set; }
        public TeacherModel Teacher { get; set; }
        public ExamType ExamType { get; set; }
        public MarkEnum MarkEnum { get; set; }



        public MarkModel Clone()
        {
            var markModel = new MarkModel()
            {
                Id = Id,
                Student = Student.Clone(),
                Teacher = Teacher.Clone(),
                ExamType = ExamType,
                MarkEnum = MarkEnum

            };

            return markModel;
        }
    }
}
