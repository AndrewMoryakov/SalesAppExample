using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext, IDataContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ProvidedProducts> ProvidedProducts { get; set; }
        public DbSet<SalesData> SalesData { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TEntity> Set<TEntity, TKey>() where TEntity : Entity<TKey> where TKey : struct
        {
            return this.Set<TEntity>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}