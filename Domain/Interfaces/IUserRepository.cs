using AutoMapper.Configuration.Conventions;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByIdAsync(int id);
        public Task<List<User>> GetAllUsersAsync();
        public Task<bool> CreateUserAsync(User user);
        public Task<bool> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(int id);


        public Task<bool> IsExist(string document);
    }
}
