using api.Services.Interfaces;

namespace api.Services.Interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
    }
}