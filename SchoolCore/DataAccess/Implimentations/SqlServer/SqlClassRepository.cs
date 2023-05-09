using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SchoolCore.DataAccess.Implimentations.SqlServer
{
    internal class SqlClassRepository : IClassRepository
    {
        private readonly string _connectionString;
        public SqlClassRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Class> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Classes where isdeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Class> clas = new List<Class>();

                    while (reader.Read())
                    {
                        Class teacher = GetFromReader(reader);

                        clas.Add(teacher);
                    }

                    return clas;
                }
            };
        }

        public Class GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Teachers where id = @id and isdeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == false)
                        return null;

                    return GetFromReader(reader);
                }
            }
        }

        public int Insert(Class clas)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Classes output inserted.id values(@name,@grade,@teacherId,
                                   @isDeleted, @creationDate, @modifiedDate,@creatorId, @modifierId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(clas, cmd);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Update(Class clas)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"update Teachers set Name = @name,Grade=@grade,TeacherId=@teacherId,
                                   IsDeleted = @isDeleted, CreationDate = @creationDate,
                                   ModifiedDate = @modifiedDate,CreatorId = @creatorId,
                                   ModifierId = @modifierId
                                   where Id = @id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", clas.Id);

                    AddParameters(clas, cmd);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private Class GetFromReader(SqlDataReader reader)
        {
            Class clas = new Class();

            clas.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            clas.Name = reader.GetString(reader.GetOrdinal("Name"));
            clas.Grade = (Grade)reader.GetByte(reader.GetOrdinal("Grade"));
            clas.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
            clas.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            clas.ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));

            clas.Teacher = new Teacher
            {
                Id = reader.GetInt32(reader.GetOrdinal("TeacherId")),
            };

            clas.Creator = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("CreatorId"))
            };

            clas.Modifier = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("ModifierId"))
            };

            return clas;
        }
        private void AddParameters(Class clas, SqlCommand command)
        {
            command.Parameters.AddWithValue("@name", clas.Name);
            command.Parameters.AddWithValue("@grade", clas.Grade);
            command.Parameters.AddWithValue("@teacherId", clas.TeacherId);
            command.Parameters.AddWithValue("@isDeleted", clas.IsDeleted);
            command.Parameters.AddWithValue("@creationTime", clas.CreationDate);
            command.Parameters.AddWithValue("@modifiedTime", clas.ModifiedDate);
            command.Parameters.AddWithValue("@creatorId", clas.CreatorId);
            command.Parameters.AddWithValue("@modifierId", clas.ModifierId);
        }
    }
}
