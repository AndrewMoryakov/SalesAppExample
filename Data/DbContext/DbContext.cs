using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext.Entities;

namespace SaleAppExample.Data.DbContext
{
    public class ApplicationDbContext : CustomBaseDataContext
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

        public override DbSet<TEntity> Set<TEntity, TKey>()
        {
            return this.Set<TEntity>();
        }
    }
}