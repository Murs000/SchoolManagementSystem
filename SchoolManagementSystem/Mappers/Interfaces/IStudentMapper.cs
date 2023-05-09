using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Interfaces
{
    internal interface IStudentMapper
    {
        StudentModel Map(Student student);
        Student Map(StudentModel studentModel);
    }
}
