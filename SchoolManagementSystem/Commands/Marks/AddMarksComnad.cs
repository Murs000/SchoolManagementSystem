using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Students
{
    internal class AddMarksComand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MarksControlViewModel _viewModel;
        public AddMarksComand(MarksControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Add;
        }
    }
}
