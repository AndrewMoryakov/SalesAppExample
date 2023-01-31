using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext _context;
	private Dictionary<Type, object> _repositories;

	public UnitOfWork(ApplicationDbContext context)
	{
		_context = context;
	}

	public void Commit() => _context.SaveChanges();
	

	public void Dispose()
	{
		_context.Dispose();
	}

	public async Task CommitAsync(CancellationToken cs) => await _context.SaveChangesAsync(cs);

	public IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : Entity<TKey>  where TKey:struct
	{
		if (_repositories == null)
		{
			_repositories = new Dictionary<Type, object>();
		}

		var type = typeof(TEntity);
		if (!_repositories.ContainsKey(type))
		{
			var repositoryType = typeof(Repository<TEntity, TKey>);
			var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
			_repositories[type] = repositoryInstance;
		}
		return (IRepository<TEntity, TKey>)_repositories[type];
	}
}