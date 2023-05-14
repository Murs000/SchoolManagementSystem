using SchoolCore.Domain.Enums;
using SchoolManagementSystem.Commands.Teachers;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels.UserControls
{
    internal class TeacherControlViewModel : BaseViewModel
    {
        private readonly ITeacherService _service;
        public TeacherControlViewModel(ITeacherService teacherService)
        {
            _service = teacherService;
            SetDefaultValues();

            AllTeachers = new List<TeacherModel>();
        }

        #region properties

        private string _currentSuccess= "Welcome" ;
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


        private ObservableCollection<TeacherModel> _teachers;
        public ObservableCollection<TeacherModel> Teachers
        {
            get => _teachers ?? (_teachers = new ObservableCollection<TeacherModel>());
            set
            {
                _teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }

        public List<TeacherModel> AllTeachers { get; set; }

        private TeacherModel _currentValue;
        public TeacherModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private TeacherModel _selectedValue;
        public TeacherModel SelectedValue
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
                    Teachers = new ObservableCollection<TeacherModel>(AllTeachers);
                }
                else
                {
                    var filteredResult = Teachers.Where(x => x.Name.StartsWith(SearchedValue) || x.Surname.StartsWith(SearchedValue));

                    Teachers = new ObservableCollection<TeacherModel>(filteredResult);
                }
            }
        }
        #endregion

        #region commands
        public AddTeachersCommand Add => new AddTeachersCommand(this);
        public DeleteTeachersCommand Delete => new DeleteTeachersCommand(this,_service);
        public EditTeachersCommand Edit => new EditTeachersCommand(this);
        public CancelTeachersCommand Cancel => new CancelTeachersCommand(this);
        public SaveTeachersCommand Save => new SaveTeachersCommand(this, _service);
        public ExelTeachersCommand Exel => new ExelTeachersCommand(this, _service);
        #endregion

        #region metods
        public void SetDefaultValues()
        {
            CurrentSituation = (int)Situation.Default;
            CurrentValue = new TeacherModel();

            SetSelectedValue(null);
        }

        private void SetSelectedValue(TeacherModel teacherModel)
        {
            _selectedValue = teacherModel;
            OnPropertyChanged(nameof(SelectedValue));
        }
        #endregion
    }
}
