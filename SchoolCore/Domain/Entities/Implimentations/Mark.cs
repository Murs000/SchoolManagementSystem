using SchoolCore.Domain.Entities.Interfaces;
using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.Domain.Entities.Implementations
{
    public class Mark : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId => Student.Id;
        public Teacher Teacher { get; set; }
        public int TeacherId => Teacher.Id;
        public ExamType ExamType { get; set; }
        public MarkEnum  MarkEnum { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatorId => Creator.Id;
        public int ModifierId => Modifier.Id;
        public User Creator { get; set; }
        public User Modifier { get; set; }
    }
}
