using SchoolCore.Domain.Entities.Implimentations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        Teacher GetById(int id);
        int Insert(USer user);
        bool Update(User user);
        bool Delete(int id);
    }
}
