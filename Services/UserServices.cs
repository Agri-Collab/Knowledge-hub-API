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
    }
}
