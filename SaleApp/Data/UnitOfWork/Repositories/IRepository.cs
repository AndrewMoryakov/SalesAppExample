using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.UnitOfWork.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey:struct
    {
        Task<TEntity> GetByIdAsync(TKey id);
        IQueryable<TEntity> GetAllAsync();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}