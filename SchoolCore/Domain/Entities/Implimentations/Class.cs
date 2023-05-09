using SchoolCore.Domain.Entities.Interfaces;
using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.Domain.Entities.Implementations
{
    public class Class : IEntity
    {
        public int Id { get ; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId => Teacher.Id;
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatorId => Creator.Id;
        public int ModifierId => Modifier.Id;
        public User Creator { get; set; }
        public User Modifier { get; set; }

    }
}
