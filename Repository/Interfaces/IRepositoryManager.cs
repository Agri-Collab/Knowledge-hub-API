using api.Repository.Interfaces;

namespace api.Repository
{
    public interface IRepositoryManager
{
        IUserRepository User { get; }
        Task SaveAsync();
}
}