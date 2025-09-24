using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Usuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                return Ok( await _service.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
