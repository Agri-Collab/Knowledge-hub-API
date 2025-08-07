using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using api.Dto;
using api.Models;
using api.Services.Interfaces;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserController(IServiceManager service, UserManager<User> userManager, IConfiguration configuration)
        {
            _service = service;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpGet("{id:int}", Name = "UserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.UserService.GetUser(id, trackChanges: false);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.UserService.GetAllUsers(trackChanges: false);
            return Ok(users);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserForCreateDto userDto)
        {
            if (userDto == null) return BadRequest("User info is required");

            var createdUser = await _service.UserService.CreateUser(userDto);
            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userExists = await _service.UserService.GetUser(id, trackChanges: false);
            if (userExists == null) return NotFound($"User with ID {id} not found.");

            await _service.UserService.DeleteUser(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserForUpdateDto userDto)
        {
            if (userDto == null) return BadRequest("User object is null");

            var userExists = await _service.UserService.GetUser(id, trackChanges: false);
            if (userExists == null) return NotFound($"User with ID {id} not found.");

            await _service.UserService.UpdateUser(id, userDto, trackChanges: true);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized("Invalid email or password");

            var token = await GenerateJwtToken(user);
            return Ok(new { token });
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
