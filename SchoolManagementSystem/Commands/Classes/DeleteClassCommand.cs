using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
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
    internal class DeleteClassCommand : BaseComand
    {
        private readonly ClassControlViewModel _viewModel;
        private readonly IClassService _classService;
        public DeleteClassCommand(ClassControlViewModel viewModel, IClassService classService)
        {
            _viewModel = viewModel;
            _classService = classService;
        }

        public override void Execute(object parameter)
        {
            int id = _viewModel.SelectedValue.Id;

            _classService.Delete(id);

            List<ClassModel> classModels = _classService.GetAll();


            _viewModel.Classes = new ObservableCollection<ClassModel>(classModels);
            _viewModel.SetDefaultValues();

        }
    }
}
