using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.UnitOfWork.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey:struct,IComparable
    {
        private readonly CustomBaseDataContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private ILogger<Entity<TKey>> _logger;

        public Repository(CustomBaseDataContext context, ILogger<Entity<TKey>> logger)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _logger = logger;
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(el => el.Id.CompareTo(id) == 0);
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual void Insert(TEntity entity)
        {
            entity.CreatedDateTime = DateTimeOffset.Now; 
            _dbSet.Add(entity);
            LoggDebug(nameof(entity), entity.Id, nameof(this.Insert));
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdatedDateTime = DateTimeOffset.Now;
            _context.Entry(entity).State = EntityState.Modified;
            LoggDebug(nameof(entity), entity.Id, nameof(this.Update));
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            LoggDebug(nameof(entity), entity.Id, nameof(this.Delete));
        }
        public async Task<bool> ExistsAsync(TKey id)
        {
            return await this.GetByIdAsync(id) != null;
        }

        private void LoggDebug(string type, TKey id, string action)
        {
            // _logger.Log(LogLevel.Information, $"{type} with id {id} is {action}");
        }
    }
}