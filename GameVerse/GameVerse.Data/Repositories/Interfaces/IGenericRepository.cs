using System.Linq.Expressions;

namespace GameVerse.Data.Repositories.Interfaces
{
    /// <summary>
    /// Defines a generic repository interface for CRUD operations with entities of type <typeparamref name="TType"/> and identifier type <typeparamref name="TId"/>.
    /// </summary>
    /// <typeparam name="TType">The entity type.</typeparam>
    /// <typeparam name="TId">The type of the entity's identifier.</typeparam>
    public interface IGenericRepository<TType, TId> 
    {
        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        TType? GetById(TId id);

        /// <summary>
        /// Asynchronously retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>A task that represents the asynchronous operation, with the entity if found; otherwise, null.</returns>
        Task<TType?> GetByIdAsync(TId id);

        /// <summary>
        /// Retrieves entities including specified related entities.
        /// </summary>
        /// <param name="includes">Related entities to include.</param>
        /// <returns>An <see cref="IQueryable{T}"/> of entities with specified includes.</returns>
        IQueryable<TType> GetWithIncludeAsync(
    params Expression<Func<TType, object>>[] includes);

        /// <summary>
        /// Retrieves the first entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">A function to test each entity for a condition.</param>
        /// <returns>The first entity that matches the predicate; otherwise, null.</returns>
        TType? FirstOrDefault(Func<TType, bool> predicate);

        /// <summary>
        /// Asynchronously retrieves the first entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">An expression to test each entity for a condition.</param>
        /// <returns>A task that represents the asynchronous operation, with the first entity that matches the predicate; otherwise, null.</returns>
        Task<TType?> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate);

        /// <summary>
        /// Retrieves all entities as a read-only collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing all entities.</returns>
        IEnumerable<TType> GetAllAsReadOnly();

        /// <summary>
        /// Asynchronously retrieves all entities as a read-only collection.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing an <see cref="IEnumerable{T}"/> of all entities.</returns>
        Task<IEnumerable<TType>> GetAllAsyncAsReadOnly();

        /// <summary>
        /// Retrieves all entities with tracking enabled.
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}"/> of all entities with tracking enabled.</returns>
        IQueryable<TType> GetAllAttached();

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(TType entity);

        /// <summary>
        /// Asynchronously adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(TType entity);

        /// <summary>
        /// Adds a range of entities to the repository.
        /// </summary>
        /// <param name="entities">An array of entities to add.</param>
        void AddRange(TType[] entities);

        /// <summary>
        /// Asynchronously adds a range of entities to the repository.
        /// </summary>
        /// <param name="entities">An array of entities to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddRangeAsync(TType[] entities);

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>True if the entity was deleted; otherwise, false.</returns>
        bool Delete(TId id);

        /// <summary>
        /// Asynchronously deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of true if the entity was deleted; otherwise, false.</returns>
        Task<bool> DeleteAsync(TId id);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>True if the entity was successfully updated; otherwise, false.</returns>
        bool Update(TType entity);

        /// <summary>
        /// Asynchronously updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of true if the entity was successfully updated; otherwise, false.</returns>
        Task<bool> UpdateAsync(TType entity);

        /// <summary>
        /// Retrieves all entities as a read-only collection.
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}"/> of all entities without tracking.</returns>
        IQueryable<TType> AllAsReadOnly();

        /// <summary>
        /// Saves changes to the repository.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Asynchronously saves changes to the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task SaveChangesAsync();
    }
}
