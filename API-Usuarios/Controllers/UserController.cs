using Domain.Interfaces;
using Domain.models;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Configuration.Conventions;
using Application.Responce;

namespace API_Usuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _service;

        public UserController(IUserServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {   
            try
            {
                var users = (await _service.GetAllUsersAsync());

                var responce = new ResponceViewModel<IEnumerable<User>>(users);
                    
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponceViewModel()
                {
                    status = false,
                    ErrorCode = "REQUEST_FAIL_GET_ALL_USERS",       //Documentar codigos de error
                    msg = $"Error al obtener los registros de los usuarios : {ex.Message}"
                });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id) 
        {
            try
            {
                var user = await _service.GetUserByIdAsync(id);

                var responce = new ResponceViewModel<User>(user);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponceViewModel()
                {
                    status = false,
                    ErrorCode = "REQUEST_FAIL_GET_USER",
                    msg = $"Error al obtener los datos del usuario con id {id} : {ex.Message}"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel user) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponceViewModel()
                {
                    status = false,
                    ErrorCode = "REQUEST_FAIL_INVALID_DATA",
                    msg = "Error en los datos enviados "
                });    
            }

            try
            {
                var status = await _service.CreateUserAsync(user);

                var responce = new ResponceViewModel()
                {
                    status = true,
                    msg = "Operacion realizada Exitosamente",
                    ErrorCode = null
                };
                    
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponceViewModel()
                {
                    status = false,
                    ErrorCode = "REQUEST_FAIL_CREATE_USER",
                    msg = $"Error al realizar el alta de un nuevo usuario.\n {ex.Message}"
                });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateModel user,int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponceViewModel()
                {
                    status = false,
                    ErrorCode = "REQUEST_FAIL_INVALID_DATA",
                    msg = "Error en los datos enviados "
                });
            }

            try
            {
                var status = await _service.UpdateUserAsync(user, id);

                var responce = new ResponceViewModel()
                {
                    status = true,
                    msg = "Operacion realizada Exitosamente",
                    ErrorCode = null
                }; 

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponceViewModel()
                {
                    status = false,
                    ErrorCode = "REQUEST_FAIL_UPDATE_USER",
                    msg = $"Error al modificar el usuario con ID {id}:\n {ex.Message}"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var status = await _service.DeleteUserAsync(id);

                var responce = new ResponceViewModel()
                {
                    status = true,
                    msg = "OPeracion realizada Exitosamente",
                    ErrorCode = null
                };
                
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponceViewModel()
                {
                    status = false,
                    ErrorCode = "REQUEST_FAIL_DELETE_USER",
                    msg = $"Error al realizar la baja del usuario con id {id}:\n {ex.Message}"
                });
            }
        }

    }
}
