using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;

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

            willSavedClass.Modifier = new User { Id = 4 };
            willSavedClass.ModifiedDate = DateTime.Now;

            if (willSavedClass.Id == 0)
            {
                willSavedClass.CreationDate = DateTime.Now;
                willSavedClass.Creator = new User() { Id = 4 };

                return _db.ClassRepository.Insert(willSavedClass);
            }
            else
            {
                var existingAuthor = _db.TeacherRepository.GetById(classModel.Id);

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

        }
    }
}
