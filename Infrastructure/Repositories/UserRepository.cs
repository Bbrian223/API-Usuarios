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

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private ISqlConnectionFactory _connectionFactory;
        private readonly string getAllQuery = "SELECT * FROM USERS";

        public UsersRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        Task<bool> IUserRepository.CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
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
                                Name = reader.GetString("fistname"),
                                Lastname = reader.GetString("lastname"),
                                Document = reader.GetString("document"),
                                telephone = reader.GetString("telephone"),
                                Address = reader.GetString("u_address"),
                                city = reader.GetString("city"),
                                province = reader.GetString("province"),
                                zip = reader.GetInt32("zip")
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

        Task<User> IUserRepository.GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
