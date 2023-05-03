using SchoolManagementSystem.Commands;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels.Windows
{
    internal class LoginViewModel
    {
        private readonly ITeacherService _teacherService;
        public LoginViewModel(ITeacherService teacherService, LoginWindow loginWindow)
        {
            _teacherService = teacherService;
            LoginWindow = loginWindow;
        }
        public SignInCommand SingIn => new SignInCommand(this,_teacherService);
        public LoginWindow LoginWindow { get;}
    }
}
