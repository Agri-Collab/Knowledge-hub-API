using api.Repository.Interfaces;

namespace api.Repository
{
    public interface IRepositoryManager
{
        IUserRepository Company { get; }
        void Save();
}
}