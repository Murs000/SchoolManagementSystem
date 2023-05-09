using SchoolCore.Domain.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        int Insert(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}
