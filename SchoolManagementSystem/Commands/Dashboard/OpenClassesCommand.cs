using SchoolManagementSystem.Services.Implimentations;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Commands.Dashboard
{
    internal class OpenClassesCommand : BaseComand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IStudentService _studentService;
        public OpenClassesCommand(DashboardViewModel viewModel, IStudentService studentService) 
        {
            _viewModel = viewModel;
            _studentService = studentService;
        }
        public override void Execute(object parameter)
        {
            ClassControl control = new ClassControl();
            ClassControlViewModel contolViewModel = new ClassControlViewModel();

            control.DataContext = contolViewModel;

            _viewModel.MainGrind.Children.Clear();
            _viewModel.MainGrind.Children.Add(control);
        }
    }
}
