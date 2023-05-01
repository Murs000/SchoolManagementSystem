﻿using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Mappers.Interfaces
{
    internal interface ITeacherMapper
    {
        TeacherModel Map(Teacher teacher);
        Teacher Map(TeacherModel teacherModel);
    }
}