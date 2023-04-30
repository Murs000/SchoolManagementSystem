using SchoolCore.Domain.Entities.Implimentations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.DataAccess.Interfaces
{
    public interface IMarkRepository
    {
        List<Mark> GetAll();
        Mark GetById(int id);
        int Insert(Mark mark);
        bool Update(Mark mark);
        bool Delete(int id);
    }
}
