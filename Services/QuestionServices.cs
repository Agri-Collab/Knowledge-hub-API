using api.Dto;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using api.Models.Exceptions;
using api.Repository;

namespace api.Services
{
    public sealed class QuestionService : IQuestionService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public QuestionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync(bool trackChanges)
        {
            var questions = await _repository.Question.GetAllQuestionsAsync(trackChanges);
            return _mapper.Map<IEnumerable<QuestionDto>>(questions);
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(int id, bool trackChanges)
        {
            var question = await _repository.Question.GetQuestionAsync(id, trackChanges);
            return _mapper.Map<QuestionDto>(question);
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionForCreateDto questionDto)
        {
            var questionEntity = _mapper.Map<Question>(questionDto);

            _repository.Question.CreateQuestion(questionEntity);
            await _repository.SaveAsync();

            return _mapper.Map<QuestionDto>(questionEntity);
        }

        public async Task UpdateQuestionAsync(int id, QuestionForUpdateDto questionDto, bool trackChanges)
        {
            var question = await _repository.Question.GetQuestionAsync(id, trackChanges)
                ?? throw new KeyNotFoundException($"Question with id {id} was not found.");

            _mapper.Map(questionDto, question);
            await _repository.SaveAsync();
        }

        public async Task DeleteQuestionAsync(int id, bool trackChanges)
        {
            var question = await _repository.Question.GetQuestionAsync(id, trackChanges)
                ?? throw new KeyNotFoundException($"Question with id {id} was not found.");

            _repository.Question.DeleteQuestion(question);
            await _repository.SaveAsync();
        }
    }
}
