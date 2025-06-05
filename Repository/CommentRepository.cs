using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

        public async Task<IEnumerable<Comment>> GetCommentsForQuestionAsync(int questionId, bool trackChanges) =>
            await FindByCondition(c => c.QuestionId == questionId, trackChanges)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

        public async Task<Comment?> GetCommentAsync(int commentId, bool trackChanges) =>
            await FindByCondition(c => c.Id == commentId, trackChanges)
                .SingleOrDefaultAsync();

        public void CreateComment(Comment comment) => Create(comment);

        public void DeleteComment(Comment comment) => Delete(comment);
    }
}
