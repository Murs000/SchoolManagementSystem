using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace SchoolCore.DataAccess.Implimentations.SqlServer
{
    public class SqlTeacherRepository : ITeacherRepository
    {
        private readonly string _connectionString;
        public SqlTeacherRepository(string connectionSting)
        {
            _connectionString = connectionSting;
        }

        public List<Teacher> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Teachers where isdeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Teacher> teachers = new List<Teacher>();

                    while (reader.Read())
                    {
                        Teacher teacher = GetFromReader(reader);

                        teachers.Add(teacher);
                    }

                    return teachers;
                }
            }
        }

        public Teacher GetById(int id)
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

        public int Insert(Teacher teacher)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Teachers output inserted.id values(@name, @surname,
                                   @fatherName, @birthDate,@gender,@email,@phone,@subject,@expirience,@position,
                                   @isDeleted, @creationDate, @modifiedDate,@creatorId, @modifierId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(teacher, cmd);

                    object v = cmd.ExecuteScalar();
                    return (int)v;
                }
            }
        }

        public bool Update(Teacher teacher)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"update Teachers set Name = @name,Surname= @surname,
                                   FatherName=@fatherName,BirthDate= @birthDate,Gender=@gender,Email=@email,Phone=@phone,
                                   Subject=@subject,Position=@position,Expirience=@expirience,
                                   IsDeleted = @isDeleted, CreationDate = @creationDate,
                                   ModifiedDate = @modifiedDate,CreatorId = @creatorId,
                                   ModifierId = @modifierId
                                   where Id = @id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", teacher.Id);

                    AddParameters(teacher, cmd);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private Teacher GetFromReader(SqlDataReader reader)
        {
            Teacher teacher = new Teacher();

            teacher.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            teacher.Name = reader.GetString(reader.GetOrdinal("Name"));
            teacher.Surname = reader.GetString(reader.GetOrdinal("Surname"));
            teacher.FatherName = reader.GetString(reader.GetOrdinal("FatherName"));
            teacher.BirthDate = reader.GetDateTime(reader.GetOrdinal("Birthdate"));
            teacher.Gender = reader.GetByte(reader.GetOrdinal("Gender"));
            teacher.Email = reader.GetString(reader.GetOrdinal("Email"));
            teacher.PhoneNumber = reader.GetString(reader.GetOrdinal("Phone"));
            teacher.Subject = reader.GetByte(reader.GetOrdinal("Subject"));
            teacher.Expirience = reader.GetByte(reader.GetOrdinal("Expirience"));
            teacher.Position = reader.GetByte(reader.GetOrdinal("Position"));
            teacher.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
            teacher.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            teacher.ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));

            teacher.Creator = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("CreatorId"))
            };

            teacher.Modifier = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("ModifierId"))
            };

            return teacher;
        }

        private void AddParameters(Teacher teacher, SqlCommand command)
        {
            command.Parameters.AddWithValue("@name", teacher.Name);
            command.Parameters.AddWithValue("@surname", teacher.Surname);
            command.Parameters.AddWithValue("@fatherName", teacher.FatherName);
            command.Parameters.AddWithValue("@birthDate", teacher.BirthDate);
            command.Parameters.AddWithValue("@gender", teacher.Gender);
            command.Parameters.AddWithValue("@email", teacher.Email);
            command.Parameters.AddWithValue("@phone", teacher.PhoneNumber);
            command.Parameters.AddWithValue("@subject", teacher.Subject);
            command.Parameters.AddWithValue("@expirience", teacher.Expirience);
            command.Parameters.AddWithValue("@position", teacher.Position);
            command.Parameters.AddWithValue("@isDeleted", teacher.IsDeleted);
            command.Parameters.AddWithValue("@creationDate", teacher.CreationDate);
            command.Parameters.AddWithValue("@modifiedDate", teacher.ModifiedDate);
            command.Parameters.AddWithValue("@creatorId", teacher.CreatorId);
            command.Parameters.AddWithValue("@modifierId", teacher.ModifierId);
        }
    }
}