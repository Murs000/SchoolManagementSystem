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
    internal class OpenUserComand : ICommand
    {
        private readonly DashboardViewModel _mainViewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public OpenUserComand(DashboardViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void Execute(object parameter)
        {
            UserControl control = new UserControl();
            UserControlViewModel controlViewModel = new UserControlViewModel();

            control.DataContext = controlViewModel;

            _mainViewModel.MainGrind.Children.Clear();
            _mainViewModel.MainGrind.Children.Add(control);
        }
    }
}
