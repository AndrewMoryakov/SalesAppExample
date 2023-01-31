using System;
using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext
{
    public interface IDataContext: IDisposable
    {
        DbSet<TEntity> Set<TEntity, TKey>() where TEntity : Entity<TKey> where TKey : struct;
        int SaveChanges();
    }
}