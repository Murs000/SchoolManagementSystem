﻿using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Dashboard
{
    internal class OpenTeacherComand : BaseComand
    {
        private readonly DashboardViewModel _mainViewModel;
        private readonly ITeacherService _teacherService;

        public OpenTeacherComand(DashboardViewModel mainViewModel,ITeacherService teacherService)
        {
            _mainViewModel = mainViewModel;
            _teacherService = teacherService;
        }

        public override void Execute(object parameter)
        {
            TeacherControl control = new TeacherControl();
            TeacherControlViewModel viewModel = new TeacherControlViewModel(_teacherService);

            List<TeacherModel> model = _teacherService.GetAll();

            viewModel.AllTeachers = model;
            viewModel.Teachers = new ObservableCollection<TeacherModel>(model);

            control.DataContext = viewModel;

            _mainViewModel.MainGrind.Children.Clear();
            _mainViewModel.MainGrind.Children.Add(control);
        }
    }
}
