using api.Models;

namespace api.Repository.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        IEnumerable<User> GetAllUser(bool trackChanges);
    }
}