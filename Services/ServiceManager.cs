using api.Repository;
using api.Services.Interfaces;

namespace api.Services{
    public sealed class ServiceManager : IServiceManager
        {
            private readonly Lazy<IUserService> _userService;
            public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
            logger)
            {
                _userService = new Lazy<IUserService>(() => new
                UserService(repositoryManager, logger));
            }
            public IUserService UserService => _userService.Value;
        }
}