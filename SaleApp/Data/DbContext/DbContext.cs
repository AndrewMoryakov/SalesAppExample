using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext
{
    public class ApplicationMemoryDbContext : CustomBaseDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SalePoint> SalesPoints { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ProvidedProduct> ProvidedProducts { get; set; }
        public DbSet<SaleData> SalesData { get; set; }

        public ApplicationMemoryDbContext(DbContextOptions options, ILogger<ApplicationMemoryDbContext> logger)
            : base(options, logger)
        {
        }

        public DbSet<TEntity> Set<TEntity, TKey>() where  TEntity:class, Entity<Guid>
        {
            return this.Set<TEntity>();
        }
    }
}