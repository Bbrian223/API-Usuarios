using Application.DTOs;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserServices
    {
        public Task<User> GetUserByIdAsync(int id);
        public Task<List<User>> GetAllUsersAsync();
        public Task<bool> CreateUserAsync(UserCreateModel dto);
        public Task<bool> UpdateUserAsync(UserUpdateModel dto, int id);
        public Task<bool> DeleteUserAsync(int id);

    }
}
