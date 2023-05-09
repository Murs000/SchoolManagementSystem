using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Implementations
{
    public class UserMapper : IUserMapper
    {
        public UserModel Map(User user)
        {
            UserModel userModel = new UserModel();

            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Surname = user.Surname;
            userModel.Email = user.Email;

            return userModel;
        }

        public User Map(UserModel userModel)
        {
            User user = new User();

            user.Id = userModel.Id;
            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.Email = userModel.Email;

            return user;
        }
    }
}
