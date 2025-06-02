using api.Models;

namespace api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
    }
}
