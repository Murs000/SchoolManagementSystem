﻿using Microsoft.Win32;
using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implementations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interfaces;
using System;
using System.Data;
using System.Collections.Generic;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Diagnostics;

namespace SchoolManagementSystem.Services.Implementations
{
    internal class ClassService : IClassService
    {
        private readonly IUnitOfWork _db;
        private readonly IClassMapper _classMapper;
        public ClassService(IUnitOfWork db, IClassMapper classMapper)
        {
            _db = db;
            _classMapper = classMapper;
        }
        public List<ClassModel> GetAll()
        {
            List<ClassModel> classModels = new List<ClassModel>();
            List<Class> classes = _db.ClassRepository.GetAll();

            int no = 1;

            foreach (var clas in classes)
            {
                ClassModel classModel = _classMapper.Map(clas);

                classModel.No = no++;

                classModels.Add(classModel);
            }

            return classModels;
        }

        public int Save(ClassModel classModel)
        {
            Class willSavedClass = _classMapper.Map(classModel);

            willSavedClass.Modifier = new User { Id = 1 };
            willSavedClass.ModifiedDate = DateTime.Now;

            if (willSavedClass.Id == 0)
            {
                willSavedClass.CreationDate = DateTime.Now;
                willSavedClass.Creator = new User() { Id = 1 };

                return _db.ClassRepository.Insert(willSavedClass);
            }
            else
            {
                var existingAuthor = _db.ClassRepository.GetById(classModel.Id);

                willSavedClass.CreationDate = existingAuthor.CreationDate;
                willSavedClass.Creator = existingAuthor.Creator;

                _db.ClassRepository.Update(willSavedClass);

                return willSavedClass.Id;
            }
        }

        public bool Delete(int id)
        {
            Class clas = _db.ClassRepository.GetById(id);

            clas.IsDeleted = true;
            clas.ModifiedDate = DateTime.Now;
            clas.Modifier = new User { Id = 4 };

            return _db.ClassRepository.Update(clas);
        }

        public void Exel()
        {
            List<ClassModel> classModels = new List<ClassModel>(GetAll());

            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                 AddExtension = true,
                 DefaultExt = "xlsx"
            };
            fileDialog.ShowDialog();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("No",typeof(int));
            dataTable.Columns.Add("Name",typeof(string));
            dataTable.Columns.Add("Teacher",typeof (int));

            foreach(var classModel in classModels)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow["No"] = classModel.No;
                dataRow["Name"] = classModel.Name;
                dataRow["Teacher"] = classModel.Teacher.Id;

                dataTable.Rows.Add(dataRow);
            }

            XLWorkbook xLWorkbook = new XLWorkbook();
            xLWorkbook.Worksheets.Add(dataTable, "Data");
            xLWorkbook.SaveAs(fileDialog.FileName);

            Process.Start(fileDialog.FileName);
        }

        public string IsValid(ClassModel classModel)
        {
            if(classModel == null)
                return "Its empity";

            if(classModel.Name == null || classModel.Name.Length > 1)
                return "Falce Name";

            if(classModel.Grade == 0)
                return "Choose Grade";

            if(classModel.Teacher == null)
                return "Choose Teacher";

            return "Success";
        }
    }
}
