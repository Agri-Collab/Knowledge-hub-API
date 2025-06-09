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
        private readonly Lazy<IQuestionRepository> _questionrepository;
        private readonly Lazy<ICommentRepository> _commenRepository;
        private readonly Lazy<IArticleRepository> _articleRepository;

        public RepositoryManager(DataContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new
            UserRepository(repositoryContext));

            _questionrepository = new Lazy<IQuestionRepository>(() => new
            QuestionRepository(repositoryContext));

            _commenRepository = new Lazy<ICommentRepository>(() => new
            CommentRepository(repositoryContext));

            _articleRepository = new Lazy<IArticleRepository>(() => new
            ArticleRepository(repositoryContext));
        }
        public IUserRepository User => _userRepository.Value;
        public IQuestionRepository Question => _questionrepository.Value;
        public ICommentRepository Comment => _commenRepository.Value;
        public IArticleRepository Article => _articleRepository.Value;
        

        //public IUserRepository User { get => throw new NotImplementedException(); }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _repositoryContext.Database.BeginTransactionAsync();
        }
    }

}