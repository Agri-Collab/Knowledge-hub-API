using System.Text.Json;
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
        public IActionResult GetCompanies()
        {
            try
            {
                var companies =
                _service.UserService.GetAllUsers(trackChanges: false);
                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}