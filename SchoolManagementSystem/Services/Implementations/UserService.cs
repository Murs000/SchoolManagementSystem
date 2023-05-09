using SchoolCore.DataAccess.Interfaces;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _db;
        private readonly IUserMapper _userMapper;
        public UserService(IUnitOfWork db, IUserMapper userMapper)
        {
            _db = db;
            _userMapper = userMapper;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public int Save(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
