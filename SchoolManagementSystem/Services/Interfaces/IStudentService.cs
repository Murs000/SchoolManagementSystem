using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Interface
{
    internal interface IStudentService
    {
        List<StudentModel> GetAll();
        int Save(StudentModel studentModel);
        bool Delete(int id);
        void Exel();

    }
}
