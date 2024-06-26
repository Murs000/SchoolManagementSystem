﻿using SchoolCore.Domain.Entities.Implementations;
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
    }
}
