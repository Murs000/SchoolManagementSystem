using SchoolCore.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.Domain.Entities.Implimentations
{
    internal class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? CreatorId => Creator?.Id;
        public int? ModifierId => Modifier?.Id;

        public User Creator { get; set; }
        public User Modifier { get; set; }
    }
}
