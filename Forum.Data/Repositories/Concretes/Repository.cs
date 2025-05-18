using Forum.Core.Entities;
using Forum.Data.Context;
using Forum.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbcontext;
        public Repository(AppDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public DbSet<T> Table { get => dbcontext.Set<T>(); }
        public async Task AddAsync(T entity) => await Table.AddAsync(entity);
        public async Task DeleteAsync(T entity) => await Task.Run(() => Table.Remove(entity));
        public async Task UpdateAsync(T entity) => await Task.Run(() => Table.Update(entity));
        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = Table;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;

        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            return await query.SingleOrDefaultAsync();
        }
        public async Task<T> GetByIdAsync(Guid id) 
        { 
            return await Table.FindAsync(id); 
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {   
            if (predicate != null)
            {
                return await Table.CountAsync(predicate);
            }
            return await Table.CountAsync();
        }

    }
}
