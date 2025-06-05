using api.Dto;
using api.Models;
using api.Repository;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using AutoMapper;

namespace api.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CommentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync(bool trackChanges)
        {
            var comments = await _repository.Comment.GetAllCommentsAsync(trackChanges);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id, bool trackChanges)
        {
            var comment = await _repository.Comment.GetCommentAsync(id, trackChanges);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<CommentDto> CreateCommentAsync(CommentForCreateDto commentDto)
        {
            var commentEntity = _mapper.Map<Comment>(commentDto);

            _repository.Comment.CreateComment(commentEntity);
            await _repository.SaveAsync();

            return _mapper.Map<CommentDto>(commentEntity);
        }

        public async Task UpdateCommentAsync(int id, CommentForUpdateDto commentDto, bool trackChanges)
        {
            var comment = await _repository.Comment.GetCommentAsync(id, trackChanges);
            if (comment == null)
                throw new KeyNotFoundException($"Comment with ID {id} not found.");

            _mapper.Map(commentDto, comment);
            await _repository.SaveAsync();
        }

        public async Task DeleteCommentAsync(int id, bool trackChanges)
        {
            var comment = await _repository.Comment.GetCommentAsync(id, trackChanges);
            if (comment == null)
                throw new KeyNotFoundException($"Comment with ID {id} not found.");

            _repository.Comment.DeleteComment(comment);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsForQuestionAsync(int questionId, bool trackChanges)
        {
            var comments = await _repository.Comment.GetCommentsForQuestionAsync(questionId, trackChanges);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

    }
}
