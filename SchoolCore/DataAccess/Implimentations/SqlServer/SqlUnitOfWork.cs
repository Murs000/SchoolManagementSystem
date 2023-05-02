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
        public SqlUnitOfWork(string serverName, string dbName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = serverName;
            builder.InitialCatalog = dbName;
            builder.IntegratedSecurity = true;

            _connectionString = builder.ConnectionString;
        }
        public ITeacherRepository TeacherRepository => new SqlTeacherRepository(_connectionString);
        public IStudentRepository StudentRepository => new SqlStudentRepository(_connectionString);

    }
}
