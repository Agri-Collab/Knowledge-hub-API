using api.Dto;
using api.Models;

namespace api.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id, bool trackChanges);
        Task<UserDto> CreateUser(UserForCreateDto userDto);
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        Task DeleteUser(int id, bool trackChanges);
        Task UpdateUser(int id, UserForUpdateDto userDto, bool trackChanges);
        Task<IEnumerable<UserDto>> GetUsersByRoles(string roleName);
    }
}
