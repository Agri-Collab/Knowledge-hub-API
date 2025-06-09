using api.Repository.Interfaces;

namespace api.Repository
{
    public interface IRepositoryManager
{
        IUserRepository User { get; }
        IQuestionRepository Question { get; }
        ICommentRepository Comment { get; }
        IArticleRepository Article { get; } 
        Task SaveAsync();
}
}