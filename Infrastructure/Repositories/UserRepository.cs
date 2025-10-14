using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.models;
using Microsoft.SqlServer;
using Microsoft.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private ISqlConnectionFactory _connectionFactory;
        private readonly string getAllQuery = "SELECT * FROM USERS WHERE u_status = 1";
        private readonly string getByIdQuery = "SELECT * FROM USERS WHERE id = @id AND u_status = 1";
        private readonly string createQuery = @"INSERT USERS (firstname,lastname,document,telephone,email,u_address,city,province,zip)
                                                VALUES (@firstname,@lastname,@document,@telephone,@email,@u_address,@city,@province,@zip)";
        private readonly string updateQuery = @"UPDATE USERS SET telephone = @telephone, email = @email, u_address = @u_address, city = @city, 
                                                province = @province, zip = @zip WHERE id = @id";
        private readonly string deleteQuery = @"UPDATE USERS SET u_status = 0 WHERE id = @id";
        private readonly string IsExistQuery = @"SELECT COUNT(*) FROM USERS WHERE document = @document";


        public UsersRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        async Task<bool> IUserRepository.CreateUserAsync(User user)
        {
            bool status = false;

            try
            {
                using (SqlConnection connection = _connectionFactory.createConnection())
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(createQuery, connection))
                    {
                        command.Parameters.AddWithValue("@firstname", user.Name);
                        command.Parameters.AddWithValue("@lastname", user.Lastname);
                        command.Parameters.AddWithValue("@document", user.Document);
                        command.Parameters.AddWithValue("@telephone", user.Telephone);
                        command.Parameters.AddWithValue("@email", user.Email);
                        command.Parameters.AddWithValue("@u_address", user.Address);
                        command.Parameters.AddWithValue("@city", user.City);
                        command.Parameters.AddWithValue("@province", user.Province);
                        command.Parameters.AddWithValue("@zip", user.Zip);

                        status = await command.ExecuteNonQueryAsync() > 0  ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        async Task<bool> IUserRepository.DeleteUserAsync(int id)
        {
            try
            {
                using (SqlConnection connection = _connectionFactory.createConnection())
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        return await command.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<List<User>> IUserRepository.GetAllUsersAsync()
        {
            List<User> list = new List<User>();

            try
            {
                using (SqlConnection connection = _connectionFactory.createConnection()) {
                    await connection.OpenAsync();

                    using SqlCommand command = new SqlCommand(getAllQuery,connection);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync()) {
                        
                        while (await reader.ReadAsync()) {
                            list.Add(new User()
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("firstname"),
                                Lastname = reader.GetString("lastname"),
                                Document = reader.GetString("document"),
                                Telephone = reader.GetString("telephone"),
                                Email = reader.GetString("email"),
                                Address = reader.GetString("u_address"),
                                City = reader.GetString("city"),
                                Province = reader.GetString("province"),
                                Zip = reader.GetInt32("zip"),
                                status = reader.GetBoolean("u_status")
                            });   
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        async Task<User> IUserRepository.GetUserByIdAsync(int id)
        {
            User user = null;

            try
            {
                using (SqlConnection connection = _connectionFactory.createConnection()) 
                {
                    await connection.OpenAsync();

                    using SqlCommand command = new SqlCommand(getByIdQuery, connection);
                    command.Parameters.AddWithValue("@id",id);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            user = new User(){
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("firstname"),
                                Lastname = reader.GetString("lastname"),
                                Document = reader.GetString("document"),
                                Telephone = reader.GetString("telephone"),
                                Email = reader.GetString("email"),
                                Address = reader.GetString("u_address"),
                                City = reader.GetString("city"),
                                Province = reader.GetString("province"),
                                Zip = reader.GetInt32("zip"),
                                status = reader.GetBoolean("u_status")
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        async Task<bool> IUserRepository.UpdateUserAsync(User user)
        {
            try
            {
                using (SqlConnection connection = _connectionFactory.createConnection()) 
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@telephone", user.Telephone);
                        command.Parameters.AddWithValue("@email", user.Email);
                        command.Parameters.AddWithValue("@u_address", user.Address);
                        command.Parameters.AddWithValue("@city", user.City);
                        command.Parameters.AddWithValue("@province", user.Province);
                        command.Parameters.AddWithValue("@zip", user.Zip);
                        command.Parameters.AddWithValue("@id", user.Id);

                        return await command.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<bool> IUserRepository.IsExist(string document)
        {
            try
            {
                using (SqlConnection connection = _connectionFactory.createConnection()) {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("QUERY", connection))
                    {
                        command.Parameters.AddWithValue("@document",document);

                        return (int?)await command.ExecuteScalarAsync() > 0;
                    }
                }
            }   
            catch (Exception)
            {
                throw;
            }
        }
    }
}
