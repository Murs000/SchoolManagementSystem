using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolCore.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ITeacherRepository TeacherRepository { get; }

    }
}
