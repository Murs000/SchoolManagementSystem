using SchoolManagementSystem.Commands;
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
        public SingInComand SingIn => new SingInComand(this);
        public LoginWindow LoginWindow { get; set; }
        public LoginViewModel(LoginWindow loginWindow) 
        {
            LoginWindow = loginWindow;
        }
    }
}
