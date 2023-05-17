using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interfaces;
using SchoolManagementSystem.ViewModels.UserControls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchoolManagementSystem.Commands.Classes
{
    internal class SaveClassCommand : BaseComand
    {
        private readonly ClassControlViewModel _viewModel;
        private readonly IClassService _classService;
        public SaveClassCommand(ClassControlViewModel viewModel, IClassService classService)
        {
            _viewModel = viewModel;
            _classService = classService;
        }

        public override void Execute(object parameter)
        {
            string success = _classService.IsValid(_viewModel.CurrentValue);
            if (success != "Success")
            {
                _viewModel.CurrentSuccess = success;
                return;
            }

            _classService.Save(_viewModel.CurrentValue);
            _viewModel.CurrentSuccess = success;

            List<ClassModel> classModels = _classService.GetAll();

            _viewModel.Classes = new ObservableCollection<ClassModel>(classModels);

            _viewModel.SetDefaultValues();
        }
    }
}
