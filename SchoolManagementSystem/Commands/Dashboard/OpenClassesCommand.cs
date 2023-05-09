using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Implimentations;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
using SchoolManagementSystem.ViewModels.UserControls;
using SchoolManagementSystem.ViewModels.Windows;
using SchoolManagementSystem.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Commands.Dashboard
{
    internal class OpenClassesCommand : BaseComand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        public OpenClassesCommand(DashboardViewModel viewModel,IClassService classService,ITeacherService teacherService) 
        {
            _viewModel = viewModel;
            _classService = classService;
            _teacherService = teacherService;
        }
        public override void Execute(object parameter)
        {
            ClassControl control = new ClassControl();
            ClassControlViewModel contolViewModel = new ClassControlViewModel(_classService);

            List<ClassModel> classModel = _classService.GetAll();

            contolViewModel.AllClasses = classModel;
            contolViewModel.Classes = new ObservableCollection<ClassModel>(classModel);

            List<TeacherModel> teacherModel = _teacherService.GetAll();

            contolViewModel.Teachers = teacherModel;

            control.DataContext = contolViewModel;

            _viewModel.MainGrind.Children.Clear();
            _viewModel.MainGrind.Children.Add(control);
        }
    }
}
