using api.Dto;
using api.Models;
using api.Repository;
using api.Services.Interfaces;
using AutoMapper;

namespace api.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ArticleService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync(bool trackChanges)
        {
            var articles = await _repository.Article.GetAllArticlesAsync(trackChanges);
            return _mapper.Map<IEnumerable<ArticleDto>>(articles);
        }

        public async Task<ArticleDto> GetArticleByIdAsync(int id, bool trackChanges)
        {
            var article = await _repository.Article.GetArticleByIdAsync(id, trackChanges);
            if (article == null)
                throw new KeyNotFoundException($"Article with ID {id} not found.");

            return _mapper.Map<ArticleDto>(article);
        }

        public async Task<ArticleDto> CreateArticleAsync(ArticleForCreateDto articleDto)
        {
            // Validate that the user exists
            var user = await _repository.User.GetUserAsync(articleDto.UserId, trackChanges: false);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {articleDto.UserId} not found.");

            var articleEntity = _mapper.Map<Article>(articleDto);
            _repository.Article.CreateArticle(articleEntity);
            await _repository.SaveAsync();

            return _mapper.Map<ArticleDto>(articleEntity);
        }

        public async Task UpdateArticleAsync(int id, ArticleForUpdateDto articleDto, bool trackChanges)
        {
            var article = await _repository.Article.GetArticleByIdAsync(id, trackChanges);
            if (article == null)
                throw new KeyNotFoundException($"Article with ID {id} not found.");

            _mapper.Map(articleDto, article);
            await _repository.SaveAsync();
        }

        public async Task DeleteArticleAsync(int id, bool trackChanges)
        {
            var article = await _repository.Article.GetArticleByIdAsync(id, trackChanges);
            if (article == null)
                throw new KeyNotFoundException($"Article with ID {id} not found.");

            _repository.Article.DeleteArticle(article);
            await _repository.SaveAsync();
        }
    }
}
