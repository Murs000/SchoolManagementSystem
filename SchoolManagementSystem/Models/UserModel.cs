using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public UserModel Clone()
        {
            return new UserModel()
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Email = Email,
                PasswordHash = PasswordHash,
            };
        }
    }
}
