using SchoolManagementSystem.Commands.Students;
using SchoolManagementSystem.Commands.Teachers;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels.UserControls
{
    internal class StudentControlViewModel : BaseViewModel
    {
        private readonly IStudentService _service;
        public StudentControlViewModel(IStudentService studentService)
        {
            _service = studentService;
        }

        #region properties

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


        private ObservableCollection<StudentModel> students;
        public ObservableCollection<StudentModel> Students
        {
            get => students ?? (students = new ObservableCollection<StudentModel>());
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        private StudentModel _currentValue;
        public StudentModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private StudentModel _selectedValue;
        public StudentModel SelectedValue
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

        public bool IsMan
        {
            get => CurrentValue?.Gender == (int)Gender.Man;
            set
            {
                if (value)
                {
                    CurrentValue.Gender = (int)Gender.Man;
                }
            }
        }

        public bool IsWoman
        {
            get => CurrentValue?.Gender == (int)Gender.Woman;
            set
            {
                if (value)
                {
                    CurrentValue.Gender = (int)Gender.Woman;
                }
            }
        }


        #endregion



        #region commands
        public AddStudentsCommand Add => new AddStudentsCommand(this);
        public DeleteStudentsCommand Delete => new DeleteStudentsCommand(this, _service);
        public EditStudentsCommand Edit => new EditStudentsCommand(this);
        public CancelStudentsCommand Cancel => new CancelStudentsCommand(this);
        public SaveStudentsCommand Save => new SaveStudentsCommand(this, _service);
        #endregion

        public void SetDefaultValues()
        {
            CurrentSituation = (int)Situation.Default;
            CurrentValue = new StudentModel();

            SetSelectedValue(null);
        }

        private void SetSelectedValue(StudentModel studentModel)
        {
            _selectedValue = studentModel;
            OnPropertyChanged(nameof(SelectedValue));
        }

    }
}
