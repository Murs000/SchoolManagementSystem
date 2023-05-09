using ClosedXML.Excel;
using Microsoft.Win32;
using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
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
    internal class StudentService : IStudentService
    {
        private readonly IUnitOfWork _db;
        private readonly IStudentMapper _studentMapper;
        public StudentService(IUnitOfWork db, IStudentMapper studentMapper)
        {
            _db = db;
            _studentMapper = studentMapper;
        }
        public List<StudentModel> GetAll()
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            List<Student> students = _db.StudentRepository.GetAll();

            int no = 1;

            foreach (var student in students)
            {
                StudentModel studentModel = _studentMapper.Map(student);

                studentModel.No = no++;

                studentModels.Add(studentModel);
            }

            return studentModels;
        }

        public int Save(StudentModel studentModel)
        {
            Student willSavedStudent = _studentMapper.Map(studentModel);

            willSavedStudent.Modifier = new User { Id = 1 };
            willSavedStudent.ModifiedDate = DateTime.Now;

            if (willSavedStudent.Id == 0)
            {
                willSavedStudent.CreationDate = DateTime.Now;
                willSavedStudent.Creator = new User() { Id = 1};

                return _db.StudentRepository.Insert(willSavedStudent);
            }
            else
            {
                var existingAuthor = _db.StudentRepository.GetById(studentModel.Id);

                willSavedStudent.CreationDate = existingAuthor.CreationDate;
                willSavedStudent.Creator = existingAuthor.Creator;

                _db.StudentRepository.Update(willSavedStudent);

                return willSavedStudent.Id;
            }
        }

        public bool Delete(int id)
        {
            Student student = _db.StudentRepository.GetById(id);

            student.IsDeleted = true;
            student.ModifiedDate = DateTime.Now;
            student.Modifier = new User { Id = 1 };

            return _db.StudentRepository.Update(student);
        }


        public void Exel()
        {
            List<StudentModel> studentModels = new List<StudentModel>(GetAll());

            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = "xlsx"
            };
            fileDialog.ShowDialog();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("No", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("Father Name", typeof(string));
            dataTable.Columns.Add("Birth Date", typeof(DateTime));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Phone Number", typeof(string));
    
            foreach (StudentModel model in studentModels)
            {
                DataRow row = dataTable.NewRow();
                row["No"] = model.No;
                row["Name"] = model.Name;
                row["Surname"] = model.Surname;
                row["Father Name"] = model.FatherName;
                row["Birth Date"] = model.BirthDate;
                row["Email"] = model.Email;
                row["Phone Number"] = model.PhoneNumber;
        
                dataTable.Rows.Add(row);
            }

            XLWorkbook workbook = new XLWorkbook();
            workbook.Worksheets.Add(dataTable, "Data");
            workbook.SaveAs(fileDialog.FileName);

            Process.Start(fileDialog.FileName);

        }
    }
}

