using System;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;

namespace SaleAppExample.Data.UnitOfWork.Repositories;

// public class SaleRepository<TKey> : Repository<Sale, Guid>
// {
// 	// private IRepository<SalePoint, Guid> _salePointRep;
// 	// private IRepository<SalesData, Guid> _salePointRep;
// 	// public SaleRepository(ApplicationDbContext context, IRepository<SalePoint, Guid> salePRep) : base(context)
// 	// {
// 	// 	_salePointRep = salePRep;
// 	// }
// 	//
// 	// public void Insert(SaleBinding entity)
// 	// {
// 	// 	// var saleData
// 	// 	// _salePointRep.Update( entity.SalePoint with{ p});
// 	// }
// }