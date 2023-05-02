using SchoolManagementSystem.Commands.Teachers;
using SchoolManagementSystem.Commands.Users;
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

        public AddUsersCommand Add => new AddUsersCommand(this);
        public DeleteUsersCommand Delete => new DeleteUsersCommand();
        public EditUsersCommand Edit => new EditUsersCommand();
        public CancelUsersCommand Cancel => new CancelUsersCommand(this);
        public SaveUsersCommand Save => new SaveUsersCommand();
    }
}