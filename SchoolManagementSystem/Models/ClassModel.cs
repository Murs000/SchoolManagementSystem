using DocumentFormat.OpenXml.Spreadsheet;
using SchoolCore.Domain.Entities.Implimentations;
using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SchoolManagementSystem.Models
{
    internal class ClassModel
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public int TeacherId => Teacher.Id;
        public Teacher Teacher { get; set; }

        public ClassModel Clone()
        {
            var classModel = new ClassModel()
            {
                Id = Id,
                Name = Name,
                Grade = Grade,
                Teacher = Teacher,
            };

            return classModel;
        }
    }
}
