//using SchoolManagementSystem.Commands.Classes;
//using SchoolManagementSystem.Commands.Marks;
//using SchoolManagementSystem.Commands.Teachers;
//using SchoolManagementSystem.Enums;
//using SchoolManagementSystem.Models;
//using SchoolManagementSystem.Services.Interface;
//using SchoolManagementSystem.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolManagementSystem.ViewModels.UserControls
//{
//    internal class MarksControlViewModel : BaseViewModel
//    {
//        private readonly IMarkService _service;
//        public MarksControlViewModel(IMarkService markService)
//        {
//            _service = markService;
//            SetDefaultValues();

//            AllMarks = new List<MarkModel>();
//        }

//        #region properties
//        private string _currentSuccess = "Welcome";
//        public string CurrentSuccess
//        {
//            get => _currentSuccess;
//            set
//            {
//                _currentSuccess = value;
//                OnPropertyChanged(nameof(CurrentSuccess));
//            }
//        }

//        private int _currentSituation = 0;
//        public int CurrentSituation
//        {
//            get => _currentSituation;
//            set
//            {
//                _currentSituation = value;
//                OnPropertyChanged(nameof(CurrentSituation));
//            }
//        }


//        private ObservableCollection<MarkModel> _marks;
//        public ObservableCollection<MarkModel> Marks
//        {
//            get => _marks ?? (_marks = new ObservableCollection<MarkModel>());
//            set
//            {
//                _marks = value;
//                OnPropertyChanged(nameof(Marks));
//            }
//        }

//        public List<StudentModel> Students { get; set; }

//        public List<TeacherModel> Teachers { get; set; }

//        public List<MarkModel> AllMarks { get; set; }

//        private MarkModel _currentValue;
//        public MarkModel CurrentValue
//        {
//            get => _currentValue;
//            set
//            {
//                _currentValue = value;
//                OnPropertyChanged(nameof(CurrentValue));
//            }
//        }

//        private MarkModel _selectedValue;
//        public MarkModel SelectedValue
//        {
//            get => _selectedValue;
//            set
//            {
//                SetSelectedValue(value);

//                if (value == null)
//                {
//                    SetDefaultValues();
//                }
//                else
//                {
//                    CurrentValue = SelectedValue.Clone();
//                    CurrentSituation = (int)Situation.Selected;
//                }
//            }
//        }

//        //private string _searchedValue;
//        //public string SearchedValue
//        //{
//        //    get => _searchedValue;
//        //    set
//        //    {
//        //        _searchedValue = value;
//        //        OnPropertyChanged(nameof(SearchedValue));

//        //        if (string.IsNullOrWhiteSpace(SearchedValue))
//        //        {
//        //            Marks = new ObservableCollection<MarkModel>(AllClasses);
//        //        }
//        //        else
//        //        {
//        //            var filteredResult = AllClasses.Where(x => x.Name.StartsWith(SearchedValue));

//        //            Marks = new ObservableCollection<MarkModel>(filteredResult);
//        //        }
//        //    }
//        //}
//        #endregion

//        #region commands
//        public AddMarksCommand Add => new AddMarksCommand(this);
//        public DeleteMarksCommand Delete => new DeleteMarksCommand(this, _service);
//        public EditMarksCommand Edit => new EditMarksCommand(this);
//        public CancelMarksCommand Cancel => new CancelMarksCommand(this);
//        public SaveMarksCommand Save => new SaveMarksCommand(this, _service);
//        public ExelMarksCommand Exel => new ExelMarksCommand(_service);
//        #endregion

//        #region metods
//        public void SetDefaultValues()
//        {
//            CurrentSituation = (int)Situation.Default;
//            CurrentValue = new MarkModel();

//            SetSelectedValue(null);
//        }

//        private void SetSelectedValue(MarkModel markModel)
//        {
//            _selectedValue = markModel;
//            OnPropertyChanged(nameof(SelectedValue));
//        }
//        #endregion
//    }
//}