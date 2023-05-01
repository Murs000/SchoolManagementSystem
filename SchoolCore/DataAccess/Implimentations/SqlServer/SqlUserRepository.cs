using SchoolCore.DataAccess.Interfaces;
using SchoolCore.Domain.Entities.Implimentations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace SchoolCore.DataAccess.Implimentations.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public SqlUserRepository(string connectionSting)
        {
            _connectionString = connectionSting;
        }

        public List<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Users where isdeleted = 0";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<User> users = new List<User>();

                    while (reader.Read())
                    {
                        User user = GetFromReader(reader);

                        users.Add(user);
                    }

                    return users;
                }
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"select * from Users where id = @id and isdeleted = 0";

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

        public int Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"Insert into Users output inserted.id values(@name, @surname,
                                 @email,@phone,@isDeleted, @creationDate, @modifiedDate,
                                 @creatorId, @modifierId )";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(teacher, cmd);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"update Authors set Name = @name,Surname= @surname,
                                   Email=@email,Phone=@phone, IsDeleted = @isDeleted,
                                   CreationDate = @creationDate,ModifiedDate = @modifiedDate,
                                   CreatorId = @creatorId,ModifierId = @modifierId
                                   where Id = @id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", user.Id);

                    AddParameters(user, cmd);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string cmdText = @"delete from Users where id = @id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private User GetFromReader(SqlDataReader reader)
        {
            User user = new User();

            user.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            user.Name = reader.GetString(reader.GetOrdinal("Name"));
            user.Surname = reader.GetString(reader.GetOrdinal("Surname"));
            user.Email = reader.GetString(reader.GetOrdinal("Email"));
            user.PhoneNumber = reader.GetString(reader.GetOrdinal("Phone"));
            user.IsDeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
            user.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            user.ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));

            user.Creator = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("CreatorId"))
            };

            user.Modifier = new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("ModifierId"))
            };

            return user;
        }

        private void AddParameters(User user, SqlCommand command)
        {
            command.Parameters.AddWithValue("@name", user.Name);
            command.Parameters.AddWithValue("@surname", user.Surname);
            command.Parameters.AddWithValue("@fatherName", user.FatherName);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@phone", user.PhoneNumber);
            command.Parameters.AddWithValue("@isDeleted", user.IsDeleted);
            command.Parameters.AddWithValue("@creationDate", user.CreationDate);
            command.Parameters.AddWithValue("@modifiedDate", user.ModifiedDate);
            command.Parameters.AddWithValue("@creatorId", user.CreatorId);
            command.Parameters.AddWithValue("@modifierId", user.ModifierId);
        }
    }
}
