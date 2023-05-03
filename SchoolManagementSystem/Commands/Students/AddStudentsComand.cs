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
    internal class AddStudentsComand : BaseComand
    {
        private readonly StudentControlViewModel _viewModel;
        public AddStudentsComand(StudentControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Add;
        }
    }
}
