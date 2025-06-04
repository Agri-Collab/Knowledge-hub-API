using api.Data;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
        public IUserRepository User => _userRepository.Value;

        //public IUserRepository User { get => throw new NotImplementedException(); }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _repositoryContext.Database.BeginTransactionAsync();
        }
    }

}