using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Marks
{
    internal class CancelMarksCommand : BaseComand
    {
        private readonly MarksControlViewModel _viewModel;
        public CancelMarksCommand(MarksControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Default;
        }
    }
}