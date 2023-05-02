using SchoolManagementSystem.Commands.Students;
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

        private bool _isMan;
        public bool IsMan
        {
            get => _isMan;
            set
            {
                CurrentValue.Gender = (int)Gender.Man;
            }
        }

        private bool _isWoman;
        public bool IsWoman
        {
            get => _isWoman;
            set
            {
                CurrentValue.Gender = (int)Gender.Woman;
            }
        }


        #endregion



        #region commands
        public AddStudentsComand Add => new AddStudentsComand(this);
        public DeleteStudensComand Delete => new DeleteStudensComand();
        public EditStudentsComand Edit => new EditStudentsComand();
        public CancelStudentsComand Cancel => new CancelStudentsComand(this);
        public SaveStudentsComand Save => new SaveStudentsComand();
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
