//using SchoolManagementSystem.Services.Interface;
//using SchoolManagementSystem.ViewModels.UserControls;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolManagementSystem.Commands.Marks
//{
//    internal class ExelMarksCommand : BaseComand
//    {
//        private readonly MarksControlViewModel _viewModel;
//        private readonly IMarkService _markService;
//        private IMarkService service;

//        public ExelMarksCommand(IMarkService service)
//        {
//            this.service = service;
//        }

//        public ExelMarksCommand(MarksControlViewModel viewModel, IMarkService markService)
//        {
//            _viewModel = viewModel;
//            _markService = markService;
//        }

//        public override void Execute(object parameter)
//        {
//            _markService.Exel();
//        }
//    }
//}

