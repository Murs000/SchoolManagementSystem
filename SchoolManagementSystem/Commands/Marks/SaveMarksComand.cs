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

namespace SchoolManagementSystem.Commands.Marks
{
    internal class SaveMarksCommand : BaseComand
    {
        private readonly MarksControlViewModel _viewModel;
        private readonly IMarkService _markService;

        public SaveMarksCommand(MarksControlViewModel viewModel, IMarkService markService)
        {
            _viewModel = viewModel;
            _markService = markService;
        }

        public override void Execute(object parameter)
        {
            _markService.Save(_viewModel.CurrentValue);

            _viewModel.Marks = new ObservableCollection<MarkModel>(_markService.GetAll());

            _viewModel.SetDefaultValues();
        }
    }
}
