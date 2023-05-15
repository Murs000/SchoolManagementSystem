using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Students
{
    internal class DeleteStudentsCommand : BaseComand
    {
        private readonly StudentControlViewModel _viewModel;
        private readonly IStudentService _studentService;
        public DeleteStudentsCommand(StudentControlViewModel viewModel, IStudentService studentService)
        {
            _viewModel = viewModel;
            _studentService = studentService;
        }

        public override void Execute(object parameter)
        {
            SureDialogWindow dialogWindow = new SureDialogWindow();
            dialogWindow.ShowDialog();
            if (dialogWindow.DialogResult != true)
                return;

            int id = _viewModel.SelectedValue.Id;

            _studentService.Delete(id);

            List<StudentModel> studentModels = _studentService.GetAll();


            _viewModel.Students = new ObservableCollection<StudentModel>(studentModels);
            _viewModel.SetDefaultValues();

        }
    }
}