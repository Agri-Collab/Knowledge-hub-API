using System.Text.Json;
using System.Threading.Tasks;
using api.Dto;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Models.Exceptions;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IServiceManager _service;

        public UserController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{id:int}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _service.UserService.GetUser(id, trackChanges: false);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetUserById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _service.UserService.GetAllUsers(trackChanges: false);
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetUsers: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreateDto userDto)
        {
            if (userDto is null)
                return BadRequest("User information could not be read");

            var createdUser = await _service.UserService.CreateUser(userDto);

            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
        }
    }
}
