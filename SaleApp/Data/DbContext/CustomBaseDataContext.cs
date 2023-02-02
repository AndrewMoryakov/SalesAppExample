using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext
{
    public class CustomBaseDataContext: Microsoft.EntityFrameworkCore.DbContext
        // where T:Microsoft.EntityFrameworkCore.DbContext
    {
        private ILogger<CustomBaseDataContext> _logger;
        public CustomBaseDataContext(DbContextOptions  options, ILogger<CustomBaseDataContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        public virtual DbSet<TEntity> Set<TEntity, TKey>() where TEntity : Entity<TKey> where TKey : struct
        {
            throw new NotImplementedException();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}