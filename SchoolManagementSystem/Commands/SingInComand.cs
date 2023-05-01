using SchoolManagementSystem.Services.Interface;
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
    internal class SingInComand : BaseComand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly ITeacherService _teacherService;
        public SingInComand(LoginViewModel loginViewModel,ITeacherService teacherService)
        {
            _loginViewModel = loginViewModel;
            _teacherService = teacherService;
            
        }

        public override void Execute(object parameter)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            DashboardViewModel dashboardViewModel = new DashboardViewModel(_teacherService);

            dashboardWindow.DataContext = dashboardViewModel;
            dashboardViewModel.MainGrind = dashboardWindow.grdMain;

            dashboardWindow.Show();
            _loginViewModel.LoginWindow.Close();
        }
    }
}
