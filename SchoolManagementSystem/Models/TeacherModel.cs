using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Subject { get; set; }
        public int Expirience { get; set; }
        public int Position { get; set; }

        public TeacherModel Clone()
        {
            return new TeacherModel()
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                FatherName = FatherName,
                BirthDate = BirthDate,
                Gender = Gender,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Subject = Subject,
                Expirience = Expirience,
                Position = Position
            };
        }
    }
}
