using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace SchoolCore.DataAccess.Implimentations.SqlServer
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly string _connectionString;
        public SqlStudentRepository(string connectionSting)
        {
            _connectionString = connectionSting;
        }

        public List<Student> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Students where isdeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {
                        Student student = GetFromReader(reader);

                        students.Add(student);
                    }

                    return students;
                }
            }
        }

        public Student GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Students where id = @id and isdeleted = 0";

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

        public int Insert(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Students output inserted.id values(@name, @surname,
                                   @fatherName, @birthDate,@gender,@email,@phone,@subject,@position,
                                   @isDeleted, @creationDate, @modifiedDate,@creatorId, @modifierId )";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(student, cmd);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Update(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"update Students set Name = @name,Surname= @surname,
                                   FatherName=@fatherName,BirthDate= @birthDate,Gender=@gender,Email=@email,Phone=@phone,
                                   IsDeleted = @isDeleted, CreationDate = @creationDate,
                                   ModifiedDate = @modifiedDate,CreatorId = @creatorId,
                                   ModifierId = @modifierId
                                   where Id = @id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", student.Id);

                    AddParameters(student, cmd);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"delete from Teachers where id = @id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private Student GetFromReader(SqlDataReader reader)
        {
            Student student = new Student();

            student.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            student.Name = reader.GetString(reader.GetOrdinal("Name"));
            student.Surname = reader.GetString(reader.GetOrdinal("Surname"));
            student.FatherName = reader.GetString(reader.GetOrdinal("FatherName"));
            student.BirthDate = reader.GetDateTime(reader.GetOrdinal("Birthdate"));
            student.Gender = reader.GetInt32(reader.GetOrdinal("Gender"));
            student.Email = reader.GetString(reader.GetOrdinal("Email"));
            student.PhoneNumber = reader.GetString(reader.GetOrdinal("Phone"));
            student.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
            student.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            student.ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));

            student.Creator = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("CreatorId"))
            };

            student.Modifier = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("ModifierId"))
            };

            return student;
        }

        private void AddParameters(Student student, SqlCommand command)
        {
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@fatherName", student.FatherName);
            command.Parameters.AddWithValue("@birthDate", student.BirthDate);
            command.Parameters.AddWithValue("@gender", student.Gender);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@phone", student.PhoneNumber);
            command.Parameters.AddWithValue("@isDeleted", student.IsDeleted);
            command.Parameters.AddWithValue("@creationDate", student.CreationDate);
            command.Parameters.AddWithValue("@modifiedDate", student.ModifiedDate);
            command.Parameters.AddWithValue("@creatorId", student.CreatorId);
            command.Parameters.AddWithValue("@modifierId", student.ModifierId);
        }
    }
}
