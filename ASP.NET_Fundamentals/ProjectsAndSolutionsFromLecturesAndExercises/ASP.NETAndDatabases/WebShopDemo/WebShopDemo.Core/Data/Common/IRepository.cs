using System.Linq.Expressions;

namespace WebShopDemo.Core.Data.Common
{
    /// <summary>
    /// Abstraction of repository access methods
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadOnly<T>() where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadOnly<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// Gets specific record from the database by primary key
        /// </summary>
        /// <param name="id">unique identifier</param>
        /// <returns>Single record</returns>
        Task<T> GetByIdAsync<T>(object id) where T : class;

        /// <summary>
        /// Gets specific record from the database by primary key
        /// </summary>
        /// <param name="id">unique identifier</param>
        /// <returns>Single record</returns>
        Task<T> GetByIdsAsync<T>(object[] ids) where T : class;

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Adds a collection of entities to the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities</param>
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Updates a record in the database
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        void Update<T>(T entity) where T : class;

        /// <summary>
        /// Updates a set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Deletes a set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be deleted</param>
        void DeleteRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Deletes a set of records in the database for which the clause is true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteWhereClause">Predicate</param>
        void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class;

        /// <summary>
        /// Deletes a record from the database
        /// </summary>
        /// <param name="id">Unique identifier</param>
        Task DeleteAsync<T>(object id) where T : class;

        /// <summary>
        /// Deletes a record from the database
        /// </summary>
        /// <param name="entity">Entity representing record to be deleted</param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// Detaches given entity from the context
        /// </summary>
        /// <param name="entity">Entity to be detached</param>
        void Detach<T>(T entity) where T : class;

        /// <summary>
        /// Disposing the context when it is not needed
        /// Don't have to call this method explicitly
        /// Leave it to the IoC container
        /// </summary>
        void Dispose();

        /// <summary>
        /// Saves all made changes in a transaction
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
