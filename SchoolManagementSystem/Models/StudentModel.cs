using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public StudentModel Clone()
        {
            return new StudentModel()
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                FatherName = FatherName,
                BirthDate = BirthDate,
                Gender = Gender,
                Email = Email,
                PhoneNumber = PhoneNumber
         
            };
        }
    }
}
