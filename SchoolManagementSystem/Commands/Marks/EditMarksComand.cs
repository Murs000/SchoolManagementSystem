using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Marks
{
    internal class EditMarksCommand : BaseComand
    {
        private MarksControlViewModel _viewModel;
        public EditMarksCommand(MarksControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Edit;
        }
    }
}
