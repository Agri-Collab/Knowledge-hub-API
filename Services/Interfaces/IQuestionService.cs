using api.Dto;

namespace api.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync(bool trackChanges);
        Task<QuestionDto> GetQuestionByIdAsync(int id, bool trackChanges);
        Task<QuestionDto> CreateQuestionAsync(QuestionForCreateDto questionDto);
        Task UpdateQuestionAsync(int id, QuestionForUpdateDto questionDto, bool trackChanges);
        Task DeleteQuestionAsync(int id, bool trackChanges);
    }
}
