using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Implimentations
{
    public class UserMapper : IUserMapper
    {
        public UserModel Map(User user)
        {
            UserModel userModel = new UserModel();

            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Surname = user.Surname;
            userModel.FatherName = user.FatherName;
            userModel.BirthDate = user.BirthDate;
            userModel.Email = user.Email;
            userModel.PhoneNumber = user.PhoneNumber;
            userModel.Subject = user.Subject;
            userModel.Expirience = user.Expirience;
            userModel.Position = user.Position;

            return userModel;
        }

        public User Map(UserModel userModel)
        {
            User user = new Teacher();

            user.Id = userModel.Id;
            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.BirthDate = userModel.BirthDate;
            user.Gender = userModel.Gender;
            user.Email = userModel.Email;
            user.PhoneNumber = userModel.PhoneNumber;
            user.Subject = userModel.Subject;
            user.Expirience = userModel.Expirience;
            user.Position = userModel.Position;

            return user;
        }
    }
}
