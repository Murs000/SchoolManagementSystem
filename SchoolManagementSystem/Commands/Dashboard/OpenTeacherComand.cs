using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Dashboard
{
    internal class OpenTeacherComand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly DashboardViewModel _mainViewModel;
        private readonly ITeacherService _teacherService;

        public OpenTeacherComand(DashboardViewModel mainViewModel,ITeacherService teacherService)
        {
            _mainViewModel = mainViewModel;
            _teacherService = teacherService;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TeacherControl control = new TeacherControl();
            TeacherControlViewModel viewModel = new TeacherControlViewModel(_teacherService);

            control.DataContext = viewModel;

            _mainViewModel.MainGrind.Children.Clear();
            _mainViewModel.MainGrind.Children.Add(control);
        }
    }
}
