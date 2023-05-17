using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.UserControls;
using System;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Dashboard
{
    internal class OpenStudentsComand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly DashboardViewModel _mainViewModel;
        private readonly IStudentService _studentService;
        //private DashboardViewModel dashboardViewModel;

        public OpenStudentsComand(DashboardViewModel mainViewModel, IStudentService studentService)
        {
            _mainViewModel = mainViewModel;
            _studentService = studentService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StudentControl control = new StudentControl();
            StudentControlViewModel viewModel = new StudentControlViewModel(_studentService);

            control.DataContext = viewModel;

            _mainViewModel.MainGrind.Children.Clear();
            _mainViewModel.MainGrind.Children.Add(control);
        }
    }
}
