using SchoolManagementSystem.Commands.Dashboard;
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
        public Grid MainGrind { get; set; }

        public OpenStudentsComand OpenStudents => new OpenStudentsComand(this);
        public OpenTeacherComand OpenTeacher => new OpenTeacherComand(this);

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnProertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
