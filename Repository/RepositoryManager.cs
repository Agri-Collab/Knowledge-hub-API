using api.Data;
using api.Repository.Interfaces;

namespace api.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(DataContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new
            UserRepository(repositoryContext));
        }
        public IUserRepository Company => _userRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
        }
}