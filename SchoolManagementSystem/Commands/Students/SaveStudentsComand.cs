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
    internal class SaveStudentsComand : BaseComand
    {
        private readonly StudentControlViewModel _viewModel;
        private readonly IStudentService _studentService;

        public SaveStudentsComand()
        {
        }

        public SaveStudentsComand(StudentControlViewModel viewModel, IStudentService studentService)
        {
            _viewModel = viewModel;
            _studentService = studentService;
        }

        public override void Execute(object parameter)
        {
            _studentService.Save(_viewModel.CurrentValue);

            List<StudentModel> studentModels = _studentService.GetAll();

            _viewModel.Students = new ObservableCollection<StudentModel>(studentModels);

            _viewModel.SetDefaultValues();

        }
    }
}

