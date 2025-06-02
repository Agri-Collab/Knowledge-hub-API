using api.Models;
using api.Repository;
using api.Services.Interfaces;

namespace api.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public UserService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<User> GetAllUser(bool trackChanges)
        {
            try
            {
                var companies =
                _repository.Company.GetAllUser(trackChanges);
            return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllUser)} service method {ex}");
            throw;
            }
        }

        public object GetAllUsers(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
