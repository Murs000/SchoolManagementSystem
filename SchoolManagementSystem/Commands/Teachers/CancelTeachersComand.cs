﻿using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Teachers
{
    internal class CancelTeachersComand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly TeacherControlViewModel _viewModel;
        public CancelTeachersComand(TeacherControlViewModel viewModel) 
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Default;
        }
    }
}