using SchoolManagementSystem.Commands.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolManagementSystem.ViewModels.Windows
{
    internal class DashboardViewModel
    {
        public Grid MainGrind { get; set; }

        public OpenStudentsComand OpenStudents => new OpenStudentsComand(this);
        public OpenTeacherComand OpenTeacher => new OpenTeacherComand(this);
    }
}
