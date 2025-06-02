using System.Text.Json;
using System.Threading.Tasks;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet("all")]
        //[Authorize]
        [HttpGet]
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
    }
}