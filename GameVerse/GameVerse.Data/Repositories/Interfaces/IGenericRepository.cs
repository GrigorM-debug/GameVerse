using System.Linq.Expressions;

namespace GameVerse.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TType, TId> 
    {
        TType? GetById(TId id);

        Task<TType?> GetByIdAsync(TId id);

        Task<IEnumerable<TType>> GetWithIncludeAsync(
    params Expression<Func<TType, object>>[] includes);
        TType? FirstOrDefault(Func<TType, bool> predicate);

        Task<TType?> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate);

        IEnumerable<TType> GetAllAsReadOnly();

        Task<IEnumerable<TType>> GetAllAsyncAsReadOnly();

        IQueryable<TType> GetAllAttached();

        void Add(TType entity);

        Task AddAsync(TType entity);

        void AddRange(TType[] entities);

        Task AddRangeAsync(TType[] entities);

        bool Delete(TId id);

        Task<bool> DeleteAsync(TId id);

        bool Update(TType entity);

        Task<bool> UpdateAsync(TType entity);

        IQueryable<TType> AllAsReadOnly();

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
