using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Interface
{
    internal interface IMarkService
    {
        List<MarkModel> GetAll();
        int Save(MarkModel markModel);
        bool Delete(int id);
        bool IsValid(MarkModel markModel);
    }
}
