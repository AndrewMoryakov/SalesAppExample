using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;

namespace SaleAppExample.Data.UnitOfWork.Repositories;

public class SaleRepository<TKey> : Repository<Sale, Guid>
{
	private IRepository<SalePoint, Guid> _salePointRep;
	private IRepository<Sale, Guid> _saleRep;
	private IRepository<SaleData, Guid> _saleDataRep;
	public SaleRepository(CustomBaseDataContext context,
		IRepository<SalePoint, Guid> salePRep, IRepository<Sale, Guid> saleRep,
		IRepository<SaleData, Guid> saleDateRep) : base(context)
	{
		_salePointRep = salePRep;
		_saleRep = saleRep;
		_saleDataRep = saleDateRep;
	}
	
	public void Insert(Sale entity)
	{

	
		
	}
}