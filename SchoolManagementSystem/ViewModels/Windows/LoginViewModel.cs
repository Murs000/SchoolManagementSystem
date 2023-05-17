using SchoolManagementSystem.Commands;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
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
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        private readonly IMarkService _markService;

        public LoginViewModel(LoginWindow loginWindow,
                              ITeacherService teacherService,
                              IClassService classService,
                              IStudentService studentService,
                              IMarkService    markService)
        {
            _teacherService = teacherService;
            _classService = classService;
            _studentService = studentService;
            _markService = markService;

            LoginWindow = loginWindow;
        }

        public SignInCommand SingIn => new SignInCommand(this, _teacherService, _classService, _studentService,_markService);
        public LoginWindow LoginWindow { get; }
    }
}
