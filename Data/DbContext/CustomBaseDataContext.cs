using System;
using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext
{
    public abstract class CustomBaseDataContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public CustomBaseDataContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public abstract DbSet<TEntity> Set<TEntity, TKey>() where TEntity : Entity<TKey> where TKey : struct;
    }
}