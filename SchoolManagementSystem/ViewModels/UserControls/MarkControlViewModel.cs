using SchoolManagementSystem.Commands.Marks;
using SchoolManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels.UserControls
{
    internal class MarksControlViewModel : INotifyPropertyChanged
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

        public AddMarksComand Add => new AddMarksComand(this);
        public DeleteMarksComand Delete => new DeleteMarksComand();
        public EditMarksComand Edit => new EditMarksComand();
        public CancelMarksComand Cancel => new CancelMarksComand(this);
        public SaveMarksComand Save => new SaveMarksComand();
    }
}