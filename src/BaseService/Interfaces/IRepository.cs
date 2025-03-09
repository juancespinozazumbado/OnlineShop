using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RoleBasedAuth.Api.Interfaces
{
    public interface IRepository<T> where T : class
    {

        /// <summary>
        /// BdSet
        /// </summary>
        public DbSet<T> Set {  get; }


        /// <summary>
        /// Create a new 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task CreateAsync(T entity);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task UpdateAsync(T entity);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task DeleteAsync(T entity);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<T>> GetAllAsync();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T?> GetByIdAsync(Guid id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="inclideProperties"></param>
        /// <returns></returns>
        public Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>> [] includeProperties);

        /// <summary>
        /// Save the changes in the database and dispose the connection
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SaveChangesAsync( CancellationToken cancellationToken = default);


    }
}
