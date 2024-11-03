using GameVerse.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameVerse.Data.Repositories
{
    public class GenericRepository<TType, TId> : IGenericRepository<TType, TId> where TType : class
    {
        private readonly GameVerseDbContext _context;
        private readonly DbSet<TType> _dbSet;

        public GenericRepository(GameVerseDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TType>();
        }

        public void Add(TType entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(TType entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void AddRange(TType[] entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }

        public async Task AddRangeAsync(TType[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TType> AllAsReadOnly()
        {
            return _dbSet.AsNoTracking();
        }

        public bool Delete(TId id)
        {
            TType? entity = GetById(id);

            if(entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            TType? entity = await GetByIdAsync(id);

            if(entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public TType? FirstOrDefault(Func<TType, bool> predicate)
        {
            TType? entity = _dbSet.FirstOrDefault(predicate);

            return entity;
        }

        public async Task<TType?> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
        {
            TType? entity = await _dbSet.FirstOrDefaultAsync(predicate);

            return entity;
        }

        public IEnumerable<TType> GetAllAsReadOnly()
        {
           return _dbSet.ToArray();
        }

        public async Task<IEnumerable<TType>> GetAllAsyncAsReadOnly()
        {
            return await _dbSet.ToArrayAsync();

        }

        public IQueryable<TType> GetAllAttached()
        {
            return _dbSet.AsQueryable();
        }

        public TType? GetById(TId id)
        {
            TType? entity = _dbSet.Find(id);

            return entity;
        }

        public async Task<TType?> GetByIdAsync(TId id)
        {
            TType? entity = await _dbSet.
                FindAsync(id);

            return entity;
        }

        public IQueryable<TType> GetWithIncludeAsync(params Expression<Func<TType, object>>[] includes)
        {
            IQueryable<TType> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public bool Update(TType entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            } 
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
