using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.UnitOfWork.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey:struct 
    {
        private readonly CustomBaseDataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CustomBaseDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbSet.FirstOrDefaultAsync(el => el.Equals(id));
        }

        public virtual IQueryable<TEntity> GetAllAsync()
        {
            return _dbSet;
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}