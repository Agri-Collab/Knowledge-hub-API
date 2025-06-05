using api.Models;

namespace api.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsForQuestionAsync(int questionId, bool trackChanges);
        Task<IEnumerable<Comment>> GetAllCommentsAsync(bool trackChanges);
        Task<Comment?> GetCommentAsync(int id, bool trackChanges);
        void CreateComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}
