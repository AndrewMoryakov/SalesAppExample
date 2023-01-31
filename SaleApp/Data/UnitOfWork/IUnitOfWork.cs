using System;
using System.Threading;
using System.Threading.Tasks;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Data.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		Task CommitAsync(CancellationToken cs);
		IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : Entity<TKey> where TKey:struct;
	}
}