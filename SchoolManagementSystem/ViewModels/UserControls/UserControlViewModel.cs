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
    internal class UserControlViewModel : INotifyPropertyChanged
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

        public AddUsersComand Add => new AddUsersComand(this);
        public DeleteUsersComand Delete => new DeleteUsersComand();
        public EditUsersComand Edit => new EditUsersComand();
        public CancelUsersComand Cancel => new CancelUsersComand(this);
        public SaveUsersComand Save => new SaveUsersComand();
    }
}