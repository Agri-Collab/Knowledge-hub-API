using System.Linq.Expressions;

namespace api.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        Task<IEnumerable<T>> GetAllAsync(bool trackChanges);
        Task<T?> GetByIdAsync(int id, bool trackChanges); 
        Task AddAsync(T entity);
        Task<bool> SaveChangesAsync(); 

        Task AddBulkAsync(List<T> entities);
        void UpdateBulk(List<T> entities);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
