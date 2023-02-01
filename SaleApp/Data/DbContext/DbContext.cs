using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public ApplicationMemoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TEntity> Set<TEntity, TKey>() where TEntity:Entity<Guid>
        {
            return this.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region seed data

            // modelBuilder.Entity<Product>().HasData(
            #endregion

            // base.OnModelCreating(modelBuilder);
        }
    }
}