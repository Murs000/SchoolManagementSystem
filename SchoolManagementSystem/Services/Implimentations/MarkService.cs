using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
using SchoolManagementSystem.Mappers.Implimentations;
using SchoolManagementSystem.Mappers.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Implimentations
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
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeacherModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(MarkModel markModel)
        {
            throw new NotImplementedException();
        }

        public int Save(MarkModel markModel)
        {
            throw new NotImplementedException();
        }

        List<MarkModel> IMarkService.GetAll()
        {
            throw new NotImplementedException();
        }



    }
}
