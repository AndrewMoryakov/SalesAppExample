using System;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;

namespace SaleAppExample.Data.UnitOfWork.Repositories;

public class SaleRepository<TKey> : Repository<Sale, Guid>
{
	public SaleRepository(ApplicationDbContext context) : base(context)
	{
	}

	public override void Insert(Sale entity)
	{
	
	}
}