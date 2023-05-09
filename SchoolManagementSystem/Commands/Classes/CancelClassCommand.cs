using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Classes
{
    internal class CancelClassCommand : BaseComand
    {
        private readonly ClassControlViewModel _viewModel;
        public CancelClassCommand(ClassControlViewModel viewModel) 
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Default;
            _viewModel.SetDefaultValues();
        }
    }
}