using SchoolManagementSystem.Commands.Students;
using SchoolManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels.UserControls
{
    internal class StudentControlViewModel : INotifyPropertyChanged
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

        public AddStudentsComand Add => new AddStudentsComand(this);
        public DeleteStudensComand Delete => new DeleteStudensComand();
        public EditStudentsComand Edit => new EditStudentsComand();
        public CancelStudentsComand Cancel => new CancelStudentsComand(this);
        public SaveStudentsComand Save => new SaveStudentsComand();
    }
}