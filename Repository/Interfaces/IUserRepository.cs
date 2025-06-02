using api.Models;

namespace api.Repository.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<User> GetUser(int id, bool trackChanges);
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        Task<User> GetUserByEmail(string userEmail, bool trackChanges);
    }

}