using SchoolManagementSystem.Commands.Teachers;
using SchoolManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels.UserControls
{
    internal class TeacherControlViewModel : INotifyPropertyChanged
    {
        private int _currentSituation = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddTeachersComand Add => new AddTeachersComand(this);
        public DeleteTeachersComand Delete => new DeleteTeachersComand();
        public EditTeachersComand Edit => new EditTeachersComand();
        public RejectTeachersComand Cancel => new RejectTeachersComand();
        public SaveTeachersComand Save => new SaveTeachersComand();
    }
}
