using api.Repository;
using api.Services.Interfaces;
using AutoMapper; // Add this using directive for IMapper
using Microsoft.AspNetCore.Identity; // Add this using directive for UserManager
using api.Models; // Assuming your User model is in api.Models

namespace api.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;

        
        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper, 
            UserManager<User> userManager) 
        {
            _userService = new Lazy<IUserService>(() =>
                new UserService(repositoryManager, logger, mapper, userManager));
        }

        public IUserService UserService => _userService.Value;
    }
}