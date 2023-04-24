using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands
{
    internal class SingInComand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        public SingInComand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;

            
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            dashboardWindow.DataContext = dashboardViewModel;
            dashboardViewModel.MainGrind = dashboardWindow.grdMain;

            dashboardWindow.Show();
            _loginViewModel.LoginWindow.Close();
        }
    }
}
