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
        public async Task<User> GetUser(int id, bool trackChanges)
        {
            var user = await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();

            if (user is null)
                throw new KeyNotFoundException($"User with id {id} was not found.");

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<User> GetUserByEmail(string userEmail, bool trackChanges)
        {
            var user = await FindByCondition(a => a.Email == userEmail, trackChanges).FirstOrDefaultAsync();

            if (user is null)
                throw new KeyNotFoundException($"User with email '{userEmail}' was not found.");

            return user;
        }

    }
}