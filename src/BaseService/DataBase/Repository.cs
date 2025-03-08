using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.contexts;
using RoleBasedAuth.Api.Interfaces;
using System.Linq.Expressions;

namespace RoleBasedAuth.Api.DataBase;

public class Repository<T> : IRepository<T> where T : class
{

    private readonly RoleBaedDbContext _dbContext;
    
    public Repository(RoleBaedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public DbSet<T> Set  => _dbContext.Set<T>();   

    public async Task CreateAsync(T entity)
    {

       var result =  await _dbContext.Set<T>().AddAsync(entity);
       await _dbContext.SaveChangesAsync(); 
    }

    public async Task DeleteAsync(T entity)
    {
        var result =  _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
       return  await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
             params Expression<Func<T, object>>[] includeProperties)
    {

        var query = _dbContext.Set<T>().AsQueryable<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if(includeProperties != null)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

                
        }

        if(orderBy != null)
        {
           return await orderBy(query).ToListAsync();
        }
        return await query.ToListAsync();


            throw new NotImplementedException();
    }

    public async Task<T?> GetByIdAsync(Guid id) 
    {
        return await _dbContext.Set<T>().FindAsync(new object[] { id });
    }


    public async Task UpdateAsync(T entity)
    {
         _dbContext.Set<T>().Update(entity);
         await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
         var result = await _dbContext.SaveChangesAsync(cancellationToken);
        
    }
}
