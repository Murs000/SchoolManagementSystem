using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Interface
{
    internal interface IUserService
    {
        List<UserModel> GetAll();
        int Save(UserModel userModel);
        bool Delete(int id);
        bool IsValid(UserModel userModel);
    }
}
