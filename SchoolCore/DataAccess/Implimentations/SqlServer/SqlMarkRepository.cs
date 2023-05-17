using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implementations;
using SchoolCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SchoolCore.DataAccess.Implimentations.SqlServer
{
    public class SqlMarkRepository : IMarkRepository
    {
        private readonly string _connectionString;
        public SqlMarkRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Mark> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Marks where isdeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Mark> mark = new List<Mark>();

                    while (reader.Read())
                    {
                        Mark student = GetFromReader(reader);

                        mark.Add(student);
                    }

                    while (reader.Read())
                    {
                        Mark teacher = GetFromReader(reader);

                        mark.Add(teacher);
                    }

                    return mark;
                }
            };
        }

        public Mark GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Marks where id = @id and isdeleted = 0";

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

        public int Insert(Mark mark)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Marks output inserted.id values(@studentId,@teacherId,@examtype,@mark,
                                   @isDeleted, @creationDate, @modifiedDate,@creatorId, @modifierId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(mark, cmd);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Update(Mark mark)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"update Marks set StudentId=@studentId,TeacherId=@teacherId,Examtype = @examtype,Mark=@mark
                                   IsDeleted = @isDeleted, CreationDate = @creationDate,
                                   ModifiedDate = @modifiedDate,CreatorId = @creatorId,
                                   ModifierId = @modifierId
                                   where Id = @id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", mark.Id);

                    AddParameters(mark, cmd);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private Mark GetFromReader(SqlDataReader reader)
        {
            Mark mark = new Mark();

            mark.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            mark.ExamType = (ExamType)reader.GetByte(reader.GetOrdinal("Examtype"));
            mark.MarkEnum = (MarkEnum)reader.GetByte(reader.GetOrdinal("Mark"));
            mark.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
            mark.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            mark.ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));

            mark.Student = new Student
            {
                Id = reader.GetInt32(reader.GetOrdinal("StudentId")),
            };

            mark.Teacher = new Teacher
            {
                Id = reader.GetInt32(reader.GetOrdinal("TeacherId")),
            };

            mark.Creator = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("CreatorId"))
            };

            mark.Modifier = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("ModifierId"))
            };

            return mark;
        }
        private void AddParameters(Mark mark, SqlCommand command)
        {
            command.Parameters.AddWithValue("@studentId", mark.StudentId);
            command.Parameters.AddWithValue("@teacherId", mark.TeacherId);
            command.Parameters.AddWithValue("@examtype", mark.ExamType);
            command.Parameters.AddWithValue("@mark", mark.MarkEnum);
            command.Parameters.AddWithValue("@isDeleted", mark.IsDeleted);
            command.Parameters.AddWithValue("@creationDate", mark.CreationDate);
            command.Parameters.AddWithValue("@modifiedDate", mark.ModifiedDate);
            command.Parameters.AddWithValue("@creatorId", mark.CreatorId);
            command.Parameters.AddWithValue("@modifierId", mark.ModifierId);
        }
    }
}