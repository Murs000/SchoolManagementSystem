using SchoolCore.Domain.Entities.Implimentations;
using SchoolCore.Domain.Enums;

namespace SchoolManagementSystem.Models
{
    internal class ClassModel
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public TeacherModel Teacher { get; set; }

        public ClassModel Clone()
        {
            var classModel = new ClassModel()
            {
                Id = Id,
                Name = Name,
                Grade = Grade,
                Teacher = Teacher.Clone(),
            };

            return classModel;
        }
    }
}
