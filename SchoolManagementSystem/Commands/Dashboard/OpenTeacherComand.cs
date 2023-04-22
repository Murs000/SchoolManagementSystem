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

        public OpenTeacherComand(DashboardViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TeacherControl control = new TeacherControl();

            control.DataContext = _mainViewModel;

            _mainViewModel.MainGrind.Children.Clear();
            _mainViewModel.MainGrind.Children.Add(control);
        }
    }
}
