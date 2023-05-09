using SchoolCore.Domain.Entities.Implementations;
using SchoolCore.Domain.Enums;
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


        private ObservableCollection<StudentModel> _students;
        public ObservableCollection<StudentModel> Students
        {
            get => _students ?? (_students = new ObservableCollection<StudentModel>());
            set
            {
                _students = value;
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

        #endregion

        #region commands
        public AddStudentsCommand Add => new AddStudentsCommand(this);
        public DeleteStudentsCommand Delete => new DeleteStudentsCommand(this, _service);
        public EditStudentsCommand Edit => new EditStudentsCommand(this);
        public CancelStudentsCommand Cancel => new CancelStudentsCommand(this);
        public SaveStudentsCommand Save => new SaveStudentsCommand(this, _service);
        public ExelStudentsCommand Exel => new ExelStudentsCommand(this, _service);

        #endregion

        #region Methods

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
        #endregion
    }
}
