using api.Data;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace api.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _repositoryContext;

        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;
        private readonly Lazy<IArticleRepository> _articleRepository;
        private readonly Lazy<IPrivateChatRepository> _privateChatRepository;
        private readonly Lazy<IPrivateMessageRepository> _privateMessageRepository;

        public RepositoryManager(DataContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(repositoryContext));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(repositoryContext));
            _articleRepository = new Lazy<IArticleRepository>(() => new ArticleRepository(repositoryContext));
            _privateChatRepository = new Lazy<IPrivateChatRepository>(() => new PrivateChatRepository(repositoryContext));
            _privateMessageRepository = new Lazy<IPrivateMessageRepository>(() => new PrivateMessageRepository(repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IQuestionRepository Question => _questionRepository.Value;
        public ICommentRepository Comment => _commentRepository.Value;
        public IArticleRepository Article => _articleRepository.Value;
        public IPrivateChatRepository PrivateChat => _privateChatRepository.Value;
        public IPrivateMessageRepository PrivateMessage => _privateMessageRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _repositoryContext.Database.BeginTransactionAsync();
        }
    }
}
