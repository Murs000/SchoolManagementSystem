using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Interfaces
{
    internal interface IClassService
    {
        List<ClassModel> GetAll();
        int Save(ClassModel classModel);
        bool Delete(int id);
        void Exel();
    }
}
