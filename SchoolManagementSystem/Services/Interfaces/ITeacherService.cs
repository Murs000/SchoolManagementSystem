using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Interface
{
    internal interface ITeacherService
    {
        List<TeacherModel> GetAll();
        int Save(TeacherModel teacherModel);
        bool Delete(int id);
        bool IsValid(TeacherModel teacherModel);
        void Exel();
    }
}
