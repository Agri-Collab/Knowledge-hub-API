using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();

        public async Task<Article> GetArticleByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();

        public void CreateArticle(Article article) => Create(article);

        public void UpdateArticle(Article article) => Update(article);

        public void DeleteArticle(Article article) => Delete(article);
    }
}
