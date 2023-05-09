using SchoolCore.DataAccess.Implimentations.SqlServer;
using SchoolCore.DataAccess.Interfaces;
using SchoolManagementSystem.Mappers.Implementations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Services.Implimentations;
using SchoolManagementSystem.Services.Interface;
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
            IUnitOfWork db = new SqlUnitOfWork(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            ITeacherMapper teacherMapper = new TeacherMapper();

            ITeacherService teacherService = new TeacherService(db,teacherMapper);

            LoginWindow loginWindow = new LoginWindow();
            LoginViewModel loginViewModel = new LoginViewModel(teacherService,loginWindow);

            loginWindow.DataContext = loginViewModel;

            MainWindow = loginWindow;
            MainWindow.Show();
        }
    }
}
