using api.Dto;

namespace api.Services.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDto>> GetAllArticlesAsync(bool trackChanges);
        Task<ArticleDto> GetArticleByIdAsync(int id, bool trackChanges);
        Task<ArticleDto> CreateArticleAsync(ArticleForCreateDto articleDto);
        Task UpdateArticleAsync(int id, ArticleForUpdateDto articleDto, bool trackChanges);
        Task DeleteArticleAsync(int id, bool trackChanges);
    }
}
