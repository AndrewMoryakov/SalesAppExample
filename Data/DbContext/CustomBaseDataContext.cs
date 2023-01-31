using System;
using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext
{
    public class CustomBaseDataContext: Microsoft.EntityFrameworkCore.DbContext
        // where T:Microsoft.EntityFrameworkCore.DbContext
    {
        public CustomBaseDataContext(DbContextOptions  options)
            : base(options)
        {
        }

        public virtual DbSet<TEntity> Set<TEntity, TKey>() where TEntity : Entity<TKey> where TKey : struct
        {
            throw new NotImplementedException();
        }
    }
}