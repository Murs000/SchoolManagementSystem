using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Commands.Teachers
{
    internal class ExelTeachersCommand : BaseComand
    {
        private readonly ITeacherService _teacherService;
        public ExelTeachersCommand(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public override void Execute(object parameter)
        {
            _teacherService.Exel();
        }
    }
}
