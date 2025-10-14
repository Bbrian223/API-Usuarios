using Application.DTOs;
using Application.models;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
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
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<bool> IUserServices.CreateUserAsync(UserCreateModel dto)
        {
            if (await _repository.IsExist(dto.Document))
                throw new Exception("El dni ingresado ya existe en la DB.");

            var user = _mapper.Map<User>(dto);

            var status = await _repository.CreateUserAsync(user);

            if (!status)
                throw new Exception("Ocurrio un error al actualizar el registro.");

            return status;
        }

        async Task<bool> IUserServices.DeleteUserAsync(int id)
        {
            if (id <= 0)
                throw new Exception("El ID debe ser mayor a 0.");

            bool status = await _repository.DeleteUserAsync(id);

            if (!status)
                throw new Exception("Ocurrio un error durante la actualizacion del registro.");

            return status;
        }

        async Task<List<User>> IUserServices.GetAllUsersAsync()
        {
            var list = await _repository.GetAllUsersAsync();

            if (list.Count() == 0)
                throw new Exception("El registro de usuarios esta vacio.");

            return list;
        }

        async Task<User> IUserServices.GetUserByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("El ID debe ser mayor a 0.");

            var user = await _repository.GetUserByIdAsync(id);

            if (user is null)
                throw new Exception($"El usuario con ID: {id}, no existe en el registro");

            return user;
        }

        async Task<bool> IUserServices.UpdateUserAsync(UserUpdateModel dto, int id)
        {
            if (id <= 0)
                throw new Exception("El ID debe ser mayor a 0.");

            var user = _mapper.Map<User>(dto);
            user.Id = id;

            bool status = await _repository.UpdateUserAsync(user);

            if (!status)
                throw new Exception("A ocurrido un error durante la actualizacion.");

            return status;
        }
    }
}
