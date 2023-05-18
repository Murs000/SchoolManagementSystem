using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Dashboard
{
    internal class OpenStudentsComand : BaseComand
    {
        private readonly DashboardViewModel _mainViewModel;
        private readonly IStudentService _studentService;

        public OpenStudentsComand(DashboardViewModel mainViewModel, IStudentService studentService)
        {
            _mainViewModel = mainViewModel;
            _studentService = studentService;
        }

        public override void Execute(object parameter)
        {
            StudentControl control = new StudentControl();
            StudentControlViewModel viewModel = new StudentControlViewModel(_studentService);

            List<StudentModel> model = _studentService.GetAll();

            viewModel.AllStudents = model;
            viewModel.Students = new ObservableCollection<StudentModel>(model);

            control.DataContext = viewModel;

            _mainViewModel.MainGrind.Children.Clear();
            _mainViewModel.MainGrind.Children.Add(control);
        }
    }
}