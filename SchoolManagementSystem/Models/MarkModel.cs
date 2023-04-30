using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class MarkModel
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


        public MarkModel Clone()
        {
            return new MarkModel()
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
