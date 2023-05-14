using ClosedXML.Excel;
using Microsoft.Win32;
using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implementations;
using SchoolCore.Domain.Enums;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Implementations
{
    internal class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _db;
        private readonly ITeacherMapper _teacherMapper;
        public TeacherService(IUnitOfWork db, ITeacherMapper teacherMapper)
        {
            _db = db;
            _teacherMapper = teacherMapper;
        }
        public List<TeacherModel> GetAll()
        {
            List<TeacherModel> teacherModels = new List<TeacherModel>();
            List<Teacher> teachers = _db.TeacherRepository.GetAll();

            int no = 1;

            foreach (var teacher in teachers)
            {
                TeacherModel teacherModel = _teacherMapper.Map(teacher);

                teacherModel.No = no++;

                teacherModels.Add(teacherModel);
            }

            return teacherModels;
        }

        public int Save(TeacherModel teacherModel)
        {
            Teacher willSavedTeacher = _teacherMapper.Map(teacherModel);

            willSavedTeacher.Modifier = new User { Id = 1 };
            willSavedTeacher.ModifiedDate = DateTime.Now;

            if (willSavedTeacher.Id == 0)
            {
                willSavedTeacher.CreationDate = DateTime.Now;
                willSavedTeacher.Creator = new User() { Id = 1 };

                return _db.TeacherRepository.Insert(willSavedTeacher);
            }
            else
            {
                var existingAuthor = _db.TeacherRepository.GetById(teacherModel.Id);

                willSavedTeacher.CreationDate = existingAuthor.CreationDate;
                willSavedTeacher.Creator = existingAuthor.Creator;

                _db.TeacherRepository.Update(willSavedTeacher);

                return willSavedTeacher.Id;
            }
        }

        public bool Delete(int id)
        {
            Teacher teacher = _db.TeacherRepository.GetById(id);

            teacher.IsDeleted = true;
            teacher.ModifiedDate = DateTime.Now;
            teacher.Modifier = new User { Id = 1 };

            return _db.TeacherRepository.Update(teacher);
        }

        public void Exel()
        {
            List<TeacherModel> teacherModels = new List<TeacherModel>(GetAll());

            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = "xlsx"
            };
            fileDialog.ShowDialog();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("No",typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("Father Name", typeof(string));
            dataTable.Columns.Add("Birth Date", typeof(DateTime));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Phone Number", typeof(string));
            dataTable.Columns.Add("Subject", typeof(string));
            dataTable.Columns.Add("Expirience", typeof(byte));
            dataTable.Columns.Add("Position", typeof(string));

            foreach (TeacherModel model in teacherModels)
            {
                DataRow row = dataTable.NewRow();
                row["No"] = model.No;
                row["Name"] = model.Name;
                row["Surname"] = model.Surname;
                row["Father Name"] = model.FatherName;
                row["Birth Date"] = model.BirthDate;
                row["Email"] = model.Email;
                row["Phone Number"] = model.PhoneNumber;
                row["Subject"] = model.Subject;
                row["Expirience"] = model.Expirience;
                row["Position"] = model.Position;

                dataTable.Rows.Add(row);
            }

            XLWorkbook workbook = new XLWorkbook();
            workbook.Worksheets.Add(dataTable,"Data");
            workbook.SaveAs(fileDialog.FileName);

            Process.Start(fileDialog.FileName);

        }

        public bool IsValid(TeacherModel teacherModel)
        {
            if(teacherModel == null) 
                return false;  

            if (teacherModel.Name == null || teacherModel.Name.Length > 25) 
                return false;

            if (teacherModel.Surname == null || teacherModel.Surname.Length > 25 )
                return false;

            if (teacherModel.FatherName == null || teacherModel.FatherName.Length > 25)
                return false;

            if (teacherModel.Email == null || teacherModel.Email.Length > 25)
                return false;

            if (teacherModel.PhoneNumber == null || teacherModel.PhoneNumber.Length > 9 )
                return false;

            if (teacherModel.BirthDate == null)
                return false;

            if (teacherModel.Gender == 0)
                return false;

            return true;
        }
    }
}
