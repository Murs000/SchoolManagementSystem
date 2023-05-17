//using SchoolManagementSystem.Models;
//using SchoolManagementSystem.Services.Interface;
//using SchoolManagementSystem.Services.Interfaces;
//using SchoolManagementSystem.ViewModels.UserControls;
//using SchoolManagementSystem.ViewModels.Windows;
//using SchoolManagementSystem.Views.UserControls;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace SchoolManagementSystem.Commands.Dashboard
//{
//    internal class OpenMarksCommand : BaseComand
//    {
//        private readonly DashboardViewModel _viewModel;
//        private readonly IMarkService _markService;
//        private readonly IStudentService _studentService;
//        private readonly ITeacherService _teacherService;
//        public OpenMarksCommand(DashboardViewModel viewModel, IMarkService markService, IStudentService studentService,ITeacherService teacherService)
//        {
//            _viewModel = viewModel;
//            _markService = markService;
//            _studentService = studentService;
//            _teacherService = teacherService;
//        }
//        public override void Execute(object parameter)
//        {
//            MarkControl control = new MarkControl();
//            MarksControlViewModel contolViewModel = new MarksControlViewModel(_markService);

//            List<MarkModel> markModel = _markService.GetAll();

//            contolViewModel.AllMarks = markModel;
//            contolViewModel.Marks = new ObservableCollection<MarkModel>(markModel);

//            List<StudentModel> studentModel = _studentService.GetAll();

//            List<TeacherModel> teacherModel = _teacherService.GetAll();

//            contolViewModel.Students = studentModel;

//            contolViewModel.Teachers = teacherModel;

//            control.DataContext = contolViewModel;

//            _viewModel.MainGrind.Children.Clear();
//            _viewModel.MainGrind.Children.Add(control);
//        }
//    }
//}
