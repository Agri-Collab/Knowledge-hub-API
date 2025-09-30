using api.Repository.Interfaces;

namespace api.Repository
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IQuestionRepository Question { get; }
        ICommentRepository Comment { get; }
        IArticleRepository Article { get; }
        IPrivateChatRepository PrivateChat { get; }
        IPrivateMessageRepository PrivateMessage { get; }
        IAdvertisementRepository Advertisement { get; }
        Task SaveAsync();
    }
}
