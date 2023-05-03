using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Users
{
    internal class AddUsersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly UserControlViewModel _viewModel;
        public AddUsersCommand(UserControlViewModel viewModel)
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
