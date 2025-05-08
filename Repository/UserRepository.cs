using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User> GetUser(string id, bool trackChanges)
        {
            var user = await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();

            if (user is null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();
        
        public async Task<User> GetUserByEmail(string userEmail, bool trackChanges)
        {
            var user = await FindByCondition(a => a.Email == userEmail, trackChanges).FirstOrDefaultAsync();

            if (user is null)
            {
                throw new ArgumentNullException("User email was not found on database");
            }

            return user;

        }
    }
}