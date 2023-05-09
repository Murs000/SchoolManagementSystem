using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Classes
{
    internal class AddClassCommand : BaseComand
    {
        private readonly ClassControlViewModel _viewModel;
        public AddClassCommand(ClassControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Add;
        }
    }
}
