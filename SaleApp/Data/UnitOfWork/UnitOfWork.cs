using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	private readonly CustomBaseDataContext _context;
	private Dictionary<Type, object> _repositories;
	private ILogger<Entity<Guid>> _logger;
	public UnitOfWork(CustomBaseDataContext context, ILogger<Entity<Guid>> logger)
	{
		_context = context;
		_logger = logger;
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
			var repositoryType = typeof(Repository<,>); //ToDo makeas DI

			var repoType = repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey));

			var repositoryInstance = Activator.CreateInstance(repoType, _context, _logger);
			_repositories[type] = repositoryInstance;
		}
		return (IRepository<TEntity, TKey>)_repositories[type];
	}
}