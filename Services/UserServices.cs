using api.Models;
using api.Repository;
using api.Services.Interfaces;

namespace api.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public UserService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
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
    }

}
