using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Interfaces
{
    internal interface IClassMapper
    {
        ClassModel Map(Class clas);
        Class Map(ClassModel classModel);
    }
}
