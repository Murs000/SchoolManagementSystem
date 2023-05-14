using SchoolManagementSystem.Commands.Classes;
using SchoolManagementSystem.Commands.Teachers;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels.UserControls
{
    internal class ClassControlViewModel : BaseViewModel
    {
        private readonly IClassService _service;
        public ClassControlViewModel(IClassService classService) 
        { 
            _service = classService;
            SetDefaultValues();

            AllClasses = new List<ClassModel>();
        }

        #region properties
        private string _currentSuccess = "Welcome";
        public string CurrentSuccess
        {
            get => _currentSuccess;
            set
            {
                _currentSuccess = value;
                OnPropertyChanged(nameof(CurrentSuccess));
            }
        }

        private int _currentSituation = 0;
        public int CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }


        private ObservableCollection<ClassModel> _classes;
        public ObservableCollection<ClassModel> Classes
        {
            get => _classes ?? (_classes = new ObservableCollection<ClassModel>());
            set
            {
                _classes = value;
                OnPropertyChanged(nameof(Classes));
            }
        }

        public List<TeacherModel> Teachers { get; set; }

        public List<ClassModel> AllClasses { get; set; }

        private ClassModel _currentValue;
        public ClassModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private ClassModel _selectedValue;
        public ClassModel SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetSelectedValue(value);

                if (value == null)
                {
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = (int)Situation.Selected;
                }
            }
        }

        private string _searchedValue;
        public string SearchedValue
        {
            get => _searchedValue;
            set
            {
                _searchedValue = value;
                OnPropertyChanged(nameof(SearchedValue));

                if (string.IsNullOrWhiteSpace(SearchedValue))
                {
                    Classes = new ObservableCollection<ClassModel>(AllClasses);
                }
                else
                {
                    var filteredResult = AllClasses.Where(x => x.Name.StartsWith(SearchedValue));

                    Classes = new ObservableCollection<ClassModel>(filteredResult);
                }
            }
        }
        #endregion

        #region commands
        public AddClassCommand Add => new AddClassCommand(this);
        public DeleteClassCommand Delete => new DeleteClassCommand(this, _service);
        public EditClassCommand Edit => new EditClassCommand(this);
        public CancelClassCommand Cancel => new CancelClassCommand(this);
        public SaveClassCommand Save => new SaveClassCommand(this, _service);
        public ExelClassCommand Exel => new ExelClassCommand();
        #endregion

        #region metods
        public void SetDefaultValues()
        {
            CurrentSituation = (int)Situation.Default;
            CurrentValue = new ClassModel();

            SetSelectedValue(null);
        }

        private void SetSelectedValue(ClassModel classModel)
        {
            _selectedValue = classModel;
            OnPropertyChanged(nameof(SelectedValue));
        }
        #endregion
    }
}
