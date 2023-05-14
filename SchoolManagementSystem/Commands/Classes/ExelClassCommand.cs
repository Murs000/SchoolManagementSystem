using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
using SchoolManagementSystem.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Commands.Classes
{
    internal class ExelClassCommand : BaseComand
    {
        private readonly IClassService  _service;
        public ExelClassCommand(IClassService classService) 
        {
            _service = classService;
        }

        public override void Execute(object parameter)
        {
            _service.Exel();   
        }
    }
}
