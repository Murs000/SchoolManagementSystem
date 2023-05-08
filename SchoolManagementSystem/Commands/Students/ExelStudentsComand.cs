using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Commands.Students
{
    internal class ExelStudentsCommand : BaseComand
    {
        private readonly StudentControlViewModel _viewModel;
        private readonly IStudentService _studentService;
        public ExelStudentsCommand(StudentControlViewModel viewModel, IStudentService studentService)
        {
            _viewModel = viewModel;
            _studentService = studentService;
        }

        public override void Execute(object parameter)
        {
            _studentService.Exel();
        }
    }
}

