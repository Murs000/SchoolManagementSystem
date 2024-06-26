using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Interfaces
{
    internal interface IUserMapper
    {
        UserModel Map(User user);
        User Map(UserModel userModel);
    }
}