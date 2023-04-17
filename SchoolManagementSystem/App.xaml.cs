using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            dashboardWindow.DataContext = dashboardViewModel;
            dashboardViewModel.MainGrind = dashboardWindow.grdMain;

            MainWindow = dashboardWindow;
            MainWindow.Show();
        }
    }
}
