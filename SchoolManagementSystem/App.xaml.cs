using SchoolCore.DataAccess.Implementations.SqlServer;
using SchoolCore.DataAccess.Interfaces;
using SchoolManagementSystem.Mappers.Implementations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Services.Implementations;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
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
            IClassMapper classMapper = new ClassMapper(teacherMapper);
            IStudentMapper studentMapper = new StudentMapper();
            IMarkMapper markMapper = new MarkMapper(studentMapper, teacherMapper);


            ITeacherService teacherService = new TeacherService(db,teacherMapper);
            IClassService classService = new ClassService(db,classMapper);
            IStudentService studentService = new StudentService(db, studentMapper);
            IMarkService markService = new MarkService(db, markMapper);

            LoginWindow loginWindow = new LoginWindow();
            LoginViewModel loginViewModel = new LoginViewModel(loginWindow, teacherService, classService, studentService,markService);

            loginWindow.DataContext = loginViewModel;

            MainWindow = loginWindow;
            MainWindow.Show();
        }
    }
}
