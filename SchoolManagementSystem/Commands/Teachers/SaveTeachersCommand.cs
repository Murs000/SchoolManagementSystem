using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands.Teachers
{
    internal class SaveTeachersCommand : BaseComand
    {
        private readonly TeacherControlViewModel _viewModel;
        private readonly ITeacherService _teacherService;


        public SaveTeachersCommand(TeacherControlViewModel viewModel, ITeacherService teacherService)
        {
            _viewModel = viewModel;
            _teacherService = teacherService;
        }

        public override void Execute(object parameter)
        {
            _teacherService.Save(_viewModel.CurrentValue);

            List<TeacherModel> teacherModels = _teacherService.GetAll();

            _viewModel.Teachers = new ObservableCollection<TeacherModel>(teacherModels);

            _viewModel.SetDefaultValues();

        }
    }
}
