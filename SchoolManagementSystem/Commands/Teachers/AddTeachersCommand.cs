using SchoolManagementSystem.Enums;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Teachers
{
    internal class AddTeachersCommand : BaseComand
    {
        private readonly TeacherControlViewModel _viewModel;
        public AddTeachersCommand(TeacherControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situation.Add;
        }
    }
}
