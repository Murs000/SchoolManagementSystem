using SchoolManagementSystem.Commands.Dashboard;
using SchoolManagementSystem.Services.Implementations;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
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
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
        public DashboardViewModel(ITeacherService teacherService, IStudentService studentService, IClassService classService)
        {
            _teacherService = teacherService;
            _studentService = studentService;
            _classService = classService;
        }

        public Grid MainGrind { get; set; }

        public OpenStudentsComand OpenStudents => new OpenStudentsComand(this, _studentService);
        public OpenTeacherComand OpenTeacher => new OpenTeacherComand(this, _teacherService);
        public OpenMarkComand OpenMark => new OpenMarkComand(this);
        public OpenClassesCommand OpenClasses => new OpenClassesCommand(this, _classService,_teacherService);

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnProertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
