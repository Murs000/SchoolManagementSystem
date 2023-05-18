using ClosedXML.Excel;
using Microsoft.Win32;
using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using SchoolManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace SchoolManagementSystem.Services.Implementations
{
    internal class MarkService : IMarkService
    {
        private readonly IUnitOfWork _db;
        private readonly IMarkMapper _markMapper;
        public MarkService(IUnitOfWork db, IMarkMapper markMapper)
        {
            _db = db;
            _markMapper = markMapper;
        }
        public List<MarkModel> GetAll()
        {
            List<MarkModel> markModels = new List<MarkModel>();
            List<Mark> marks = _db.MarkRepository.GetAll();

            int no = 1;

            foreach (var mark in marks)
            {
                MarkModel markModel = _markMapper.Map(mark);

                markModel.No = no++;

                markModels.Add(markModel);
            }

            return markModels;
        }

        public int Save(MarkModel markModel)
        {
            Mark willSavedMark = _markMapper.Map(markModel);

            willSavedMark.Modifier = new User { Id = 4 };
            willSavedMark.ModifiedDate = DateTime.Now;

            if (willSavedMark.Id == 0)
            {
                willSavedMark.CreationDate = DateTime.Now;
                willSavedMark.Creator = new User() { Id = 4 };

                return _db.MarkRepository.Insert(willSavedMark);
            }
            else
            {
                var existingAuthor = _db.MarkRepository.GetById(markModel.Id);

                willSavedMark.CreationDate = existingAuthor.CreationDate;
                willSavedMark.Creator = existingAuthor.Creator;

                _db.MarkRepository.Update(willSavedMark);

                return willSavedMark.Id;
            }
        }

        public bool Delete(int id)
        {
            Mark mark = _db.MarkRepository.GetById(id);

            mark.IsDeleted = true;
            mark.ModifiedDate = DateTime.Now;
            mark.Modifier = new User { Id = 4 };

            return _db.MarkRepository.Update(mark);
        }

        public void Exel()
        {
            List<MarkModel> markModels = new List<MarkModel>(GetAll());

            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = "xlsx"
            };
            fileDialog.ShowDialog();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("No", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Teacher", typeof(int));

            foreach (var markModel in markModels)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow["No"] = markModel.No;
                dataRow["Student"] = markModel.Student.Id;
                dataRow["Teacher"] = markModel.Teacher.Id;
                dataRow["Examtype"] = markModel.ExamType;
                dataRow["Mark"] = markModel.MarkEnum;

                dataTable.Rows.Add(dataRow);
            }

            XLWorkbook xLWorkbook = new XLWorkbook();
            xLWorkbook.Worksheets.Add(dataTable, "Data");
            xLWorkbook.SaveAs(fileDialog.FileName);

            Process.Start(fileDialog.FileName);
        }

        public string IsValid(MarkModel markModel)
        {
            if (markModel == null)
                return "Its empity";

            if (markModel.ExamType == 0)
                return "False ExamType";

            if (markModel.MarkEnum == 0)
                return "False Mark";

            if (markModel.Student == null)
                return "Choose Student";

            if (markModel.Teacher == null)
                return "Choose Teacher";

            return "Success";
        }
    }
}
