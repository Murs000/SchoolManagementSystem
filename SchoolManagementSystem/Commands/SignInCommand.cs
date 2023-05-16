using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
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
    internal class SignInCommand : BaseComand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly IMarkService _markService;

        public SignInCommand(LoginViewModel loginViewModel,ITeacherService teacherService, IClassService classService, IStudentService studentService, IMarkService markService) 
        { 
        
            _loginViewModel = loginViewModel;
            _teacherService = teacherService;
            _classService = classService;
            _studentService = studentService;
            _markService  = markService;
        }

        public override void Execute(object parameter)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            DashboardViewModel dashboardViewModel = new DashboardViewModel(_teacherService,_studentService,_classService,_markService);

            dashboardWindow.DataContext = dashboardViewModel;
            dashboardViewModel.MainGrind = dashboardWindow.grdMain;

            dashboardWindow.Show();
            _loginViewModel.LoginWindow.Close();
        }
    }
}
