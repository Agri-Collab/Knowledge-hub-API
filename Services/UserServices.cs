using api.Dto;
using api.Models;
using api.Configuration;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using api.Models.Exceptions;
using api.Repository;
using AutoMapper;

namespace api.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;


        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager; 
        }
        
        public async Task<UserDto> GetUser(int id, bool trackChanges)
        {
            var user = await _repository.User.GetUser(id, trackChanges);

            var userDto = _mapper.Map<UserDto>(user);

            var role = await _userManager.GetRolesAsync(user);

            userDto.Roles = role;

            return userDto;
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges)
        {
            try
            {
                var users = await _repository.User.GetAllUsers(trackChanges);
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in {nameof(GetAllUsers)}: {ex}");
                throw;
            }
        }
        
        public async Task<UserDto> CreateUser(UserForCreateDto userDto)
        {
            
            var user = _mapper.Map<User>(userDto);

            var userEmail = await _userManager.FindByEmailAsync(userDto.Email);
            if (userEmail != null)
            {
                throw new BadRequestException("The provided email already exists."); 
            }

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create user: {errors}");
            }

            if (!string.IsNullOrWhiteSpace(userDto.Role))
            {
                var roleResult = await _userManager.AddToRoleAsync(user, userDto.Role);
                if (!roleResult.Succeeded)
                {
                    await _userManager.DeleteAsync(user); 
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to add user to role: {errors}");
                }
            }

            var userToReturn = _mapper.Map<UserDto>(user);

            return userToReturn;
        }
        public async Task DeleteUser(int id, bool trackChanges)
        {
            var user = await _repository.User.GetUser(id, trackChanges) ?? throw new UserNotFoundException(id);

            _repository.User.DeleteUser(user);
            await _repository.SaveAsync();
        }

        public async Task UpdateUser(int id, UserForUpdateDto userDto, bool trackChanges)
        {

            var userEntity = await _repository.User.GetUser(id, trackChanges) ?? throw new UserNotFoundException(id);

            _mapper.Map(userDto, userEntity);
            await _repository.SaveAsync();
        }
        public async Task<IEnumerable<UserDto>> GetUsersByRoles(string roleName)
        {
            var users = await _userManager.GetUsersInRoleAsync(roleName);

            return users.Select(q => new UserDto
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.Name,
                Lastname = q.Surname
            }).ToList();
        }
    }

}
