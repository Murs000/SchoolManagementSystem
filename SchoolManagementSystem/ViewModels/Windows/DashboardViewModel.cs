using SchoolManagementSystem.Commands.Dashboard;
using SchoolManagementSystem.Services.Implimentations;
using SchoolManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolManagementSystem.ViewModels.Windows
{
    internal class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly ITeacherService _teacherService;
        public DashboardViewModel(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public Grid MainGrind { get; set; }

        public OpenStudentsComand OpenStudents => new OpenStudentsComand(this);
        public OpenTeacherComand OpenTeacher => new OpenTeacherComand(this,_teacherService);

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnProertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
