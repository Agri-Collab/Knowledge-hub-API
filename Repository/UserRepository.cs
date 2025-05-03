using api.Data;
using api.Models;
using api.Repository.Interfaces;

namespace api.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void CreateUser(User user)
        {
            Create(user);
        }
        public void UpdateUser(User user)
        {
            Update(user);
        }
        public void DeleteUser(User user)
        {

            Delete(user);

        }
    }
}