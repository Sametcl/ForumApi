using Forum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class , IEntityBase, new()    
    {
        Task AddAsync(T entity);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate=null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

    }
}
