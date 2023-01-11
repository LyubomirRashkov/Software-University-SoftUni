using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace WebShopDemo.Core.Data.Common
{
    /// <summary>
    /// Implementation of repository access methods for Relational Database Engine
    /// </summary>
    /// <typeparam name="T">Type of the data table to which current repository is attached</typeparam>
    public class Repository : IRepository
    {
        /// <summary>
        /// Entity framework DB context holding connection information and properties and tracking entity states
        /// </summary>
        protected DbContext Context { get; set; }

        /// <summary>
        /// Representation of a table in the database
        /// </summary>
        protected DbSet<T> DbSet<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        public Repository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        public async Task AddAsync<T>(T entity) where T : class
        {
            await this.DbSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// Adds a collection of entities to the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities</param>
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await this.DbSet<T>().AddRangeAsync(entities);
        }

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        public IQueryable<T> All<T>() where T : class
        {
            return this.DbSet<T>().AsQueryable();
        }

        /// <summary>
        /// All records in a table which meet the desired criteria
        /// </summary>
        /// <returns>Queryable expression tree</returns>
        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class
        {
            return this.DbSet<T>().Where(search).AsQueryable();
        }

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return this.DbSet<T>().AsNoTracking();
        }

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <returns>Expression tree</returns>
        public IQueryable<T> AllReadOnly<T>(Expression<Func<T, bool>> search) where T : class
        {
            return this.DbSet<T>().Where(search).AsNoTracking();
        }

        /// <summary>
        /// Gets specific record from the database by primary key
        /// </summary>
        /// <param name="id">unique identifier</param>
        /// <returns>Single record</returns>
        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await this.DbSet<T>().FindAsync(id);
        }

        /// <summary>
        /// Gets specific record from the database by primary key
        /// </summary>
        /// <param name="id">unique identifier</param>
        /// <returns>Single record</returns>
        public async Task<T> GetByIdsAsync<T>(object[] ids) where T : class
        {
            return await this.DbSet<T>().FindAsync(ids);
        }

        /// <summary>
        /// Updates a record in the database
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        public void Update<T>(T entity) where T : class
        {
            this.DbSet<T>().Update(entity);
        }

        /// <summary>
        /// Updates a set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            this.DbSet<T>().UpdateRange(entities);
        }

        /// <summary>
        /// Deletes a set of records in the database
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be deleted</param>
        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            this.DbSet<T>().RemoveRange(entities);
        }

        /// <summary>
        /// Deletes a set of records in the database which meet the desired criteria
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteWhereClause">Predicate</param>
        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class
        {
            var entities = All<T>(deleteWhereClause);

            this.DeleteRange(entities);
        }

        /// <summary>
        /// Deletes a record from the database
        /// </summary>
        /// <param name="id">Unique identifier</param>
        public async Task DeleteAsync<T>(object id) where T : class
        {
            T entity = await GetByIdAsync<T>(id);

            this.Delete<T>(entity);
        }

        /// <summary>
        /// Deletes a record from the database
        /// </summary>
        /// <param name="entity">Entity representing record to be deleted</param>
        public void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        /// <summary>
        /// Detaches given entity from the context
        /// </summary>
        /// <param name="entity">Entity to be detached</param>
        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        /// <summary>
        /// Disposing the context when it is not needed
        /// Don't have to call this method explicitly
        /// Leave it to the IoC container
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }

        /// <summary>
        /// Saves all made changes in a transaction
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }
    }
}
