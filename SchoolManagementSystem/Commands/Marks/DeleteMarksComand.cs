//using SchoolManagementSystem.Models;
//using SchoolManagementSystem.Services.Interface;
//using SchoolManagementSystem.ViewModels.UserControls;
//using SchoolManagementSystem.Views.Windows;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace SchoolManagementSystem.Commands.Marks
//{
//    internal class DeleteMarksCommand : BaseComand
//    {
//        private readonly MarksControlViewModel _viewModel;
//        private readonly IMarkService _markService;
//        public DeleteMarksCommand(MarksControlViewModel viewModel, IMarkService markService)
//        {
//            _viewModel = viewModel;
//            _markService = markService;
//        }

//        public override void Execute(object parameter)
//        {
//            SureDialogWindow dialogWindow = new SureDialogWindow();
//            dialogWindow.ShowDialog();
//            if (dialogWindow.DialogResult != true)
//                return;

//            int id = _viewModel.SelectedValue.Id;

//            _markService.Delete(id);

//            List<MarkModel> markModels = _markService.GetAll();


//            _viewModel.Marks = new ObservableCollection<MarkModel>(markModels);
//            _viewModel.SetDefaultValues();

//        }
//    }
//}

