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
    internal class DeleteTeachersCommand : BaseComand
    {
        private readonly TeacherControlViewModel _viewModel;
        private readonly ITeacherService _teacherService;
        public DeleteTeachersCommand(TeacherControlViewModel viewModel, ITeacherService authorService)
        {
            _viewModel = viewModel;
            _teacherService = authorService;
        }

        public override void Execute(object parameter)
        {
            int id = _viewModel.SelectedValue.Id;

            _teacherService.Delete(id);

            List<TeacherModel> teacherModels = _teacherService.GetAll();


            _viewModel.Teachers = new ObservableCollection<TeacherModel>(teacherModels);
            _viewModel.SetDefaultValues();

        }
    }
}
