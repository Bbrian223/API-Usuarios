using Domain.Interfaces;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        Task<bool> IUserServices.CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserServices.DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<List<User>> IUserServices.GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();            
        }

        Task<User> IUserServices.GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserServices.UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
