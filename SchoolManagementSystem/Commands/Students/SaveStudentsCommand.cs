using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Students
{
    internal class SaveStudentsCommand : BaseComand
    {
        private readonly StudentControlViewModel _viewModel;
        private readonly IStudentService _studentService;


        public SaveStudentsCommand(StudentControlViewModel viewModel, IStudentService studentService)
        {
            _viewModel = viewModel;
            _studentService = studentService;
        }

        public override void Execute(object parameter)
        {
            string success = _studentService.IsValid(_viewModel.CurrentValue);
            if (success != "Success")
            {
                _viewModel.CurrentSuccess = success;
                return;
            }

            _studentService.Save(_viewModel.CurrentValue);
            _viewModel.CurrentSuccess = success;

            List<StudentModel> studentModels = _studentService.GetAll();

            _viewModel.Students = new ObservableCollection<StudentModel>(studentModels);

            _viewModel.SetDefaultValues();

        }
    }
}




