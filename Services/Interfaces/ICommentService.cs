using api.Dto;

namespace api.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllCommentsAsync(bool trackChanges);
        Task<CommentDto> GetCommentByIdAsync(int id, bool trackChanges);
        Task<CommentDto> CreateCommentAsync(CommentForCreateDto commentDto);
        Task UpdateCommentAsync(int id, CommentForUpdateDto commentDto, bool trackChanges);
        Task DeleteCommentAsync(int id, bool trackChanges);
        Task<IEnumerable<CommentDto>> GetCommentsForQuestionAsync(int questionId, bool trackChanges);

    }
}
