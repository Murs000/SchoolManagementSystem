using SchoolCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SchoolCore.DataAccess.Implimentations.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ITeacherRepository TeacherRepository => new SqlTeacherRepository(_connectionString);
        public IStudentRepository StudentRepository => new SqlStudentRepository(_connectionString);
        public IClassRepository ClassRepository => new SqlClassRepository(_connectionString);

    }
}
