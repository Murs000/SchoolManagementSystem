using SchoolCore.Domain.Entities.Interfaces;
using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.Domain.Entities.Implimentations
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatorId => Creator?.Id ?? 0;
        public int ModifierId => Modifier?.Id ?? 0;
        public User Creator { get; set; }
        public User Modifier { get; set; }
    }
}
