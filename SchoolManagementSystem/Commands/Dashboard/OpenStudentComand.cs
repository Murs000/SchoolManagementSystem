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
    internal class OpenStudentsComand : ICommand
    {
        private readonly DashboardViewModel _mainViewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public OpenStudentsComand(DashboardViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void Execute(object parameter)
        {
            StudentControl control = new StudentControl();
            StudentControlViewModel controlViewModel = new StudentControlViewModel();

            control.DataContext = controlViewModel;

            _mainViewModel.MainGrind.Children.Clear();
            _mainViewModel.MainGrind.Children.Add(control);
        }
    }
}
