using api.Models;

public interface IArticleRepository
{
    
    Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges);
    Task<Article> GetArticleByIdAsync(int id, bool trackChanges);
    void CreateArticle(Article article);
    void UpdateArticle(Article article);
    void DeleteArticle(Article article);
}
