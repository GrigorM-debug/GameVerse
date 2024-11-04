using GameVerse.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameVerse.Data.Repositories
{
    /// <summary>
    /// Generic repository implementation for CRUD operations on entities of type <typeparamref name="TType"/> with identifier type <typeparamref name="TId"/>.
    /// </summary>
    /// <typeparam name="TType">The entity type.</typeparam>
    /// <typeparam name="TId">The type of the entity's identifier.</typeparam>
    public class GenericRepository<TType, TId> : IGenericRepository<TType, TId> where TType : class
    {
        private readonly GameVerseDbContext _context;
        private readonly DbSet<TType> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TType, TId}"/> class with the specified context.
        /// </summary>
        /// <param name="context">The database context.</param>
        public GenericRepository(GameVerseDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TType>();
        }

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void Add(TType entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Asynchronously adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddAsync(TType entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a range of entities to the repository.
        /// </summary>
        /// <param name="entities">An array of entities to add.</param>
        public void AddRange(TType[] entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }

        /// <summary>
        /// Asynchronously adds a range of entities to the repository.
        /// </summary>
        /// <param name="entities">An array of entities to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddRangeAsync(TType[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Saves changes to the repository.
        /// </summary>
        public IQueryable<TType> AllAsReadOnly()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>True if the entity was deleted; otherwise, false.</returns>
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

        /// <summary>
        /// Asynchronously deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of true if the entity was deleted; otherwise, false.</returns>
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

        /// <summary>
        /// Retrieves the first entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">A function to test each entity for a condition.</param>
        /// <returns>The first entity that matches the predicate; otherwise, null.</returns>
        public TType? FirstOrDefault(Func<TType, bool> predicate)
        {
            TType? entity = _dbSet.FirstOrDefault(predicate);

            return entity;
        }

        /// <summary>
        /// Asynchronously retrieves the first entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">An expression to test each entity for a condition.</param>
        /// <returns>A task that represents the asynchronous operation, with the first entity that matches the predicate; otherwise, null.</returns>
        public async Task<TType?> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
        {
            TType? entity = await _dbSet.FirstOrDefaultAsync(predicate);

            return entity;
        }

        /// <summary>
        /// Retrieves all entities as a read-only collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all entities.</returns>
        public IEnumerable<TType> GetAllAsReadOnly()
        {
           return _dbSet.ToArray();
        }

        /// <summary>
        /// Asynchronously retrieves all entities as a read-only collection.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing an <see cref="IEnumerable{T}"/> of all entities.</returns>
        public async Task<IEnumerable<TType>> GetAllAsyncAsReadOnly()
        {
            return await _dbSet.ToArrayAsync();

        }

        /// <summary>
        /// Retrieves all entities with tracking enabled.
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}"/> of all entities with tracking enabled.</returns>
        public IQueryable<TType> GetAllAttached()
        {
            return _dbSet.AsQueryable();
        }

        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        public TType? GetById(TId id)
        {
            TType? entity = _dbSet.Find(id);

            return entity;
        }

        /// <summary>
        /// Asynchronously retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>A task that represents the asynchronous operation, with the entity if found; otherwise, null.</returns>
        public async Task<TType?> GetByIdAsync(TId id)
        {
            TType? entity = await _dbSet.
                FindAsync(id);

            return entity;
        }

        /// <summary>
        /// Retrieves entities including specified related entities.
        /// </summary>
        /// <param name="includes">Related entities to include.</param>
        /// <returns>An <see cref="IQueryable{T}"/> of entities with specified includes.</returns>
        public IQueryable<TType> GetWithIncludeAsync(params Expression<Func<TType, object>>[] includes)
        {
            IQueryable<TType> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>True if the entity was successfully updated; otherwise, false.</returns>
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

        /// <summary>
        /// Asynchronously updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of true if the entity was successfully updated; otherwise, false.</returns>
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

        /// <summary>
        /// Saves changes to the repository.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves changes to the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
