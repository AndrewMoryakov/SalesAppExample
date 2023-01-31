using System;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class SaleController : UniversalController<Sale, Guid>
{
	public SaleController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	// public Task<ActionResult<Entity<Guid>>> Post(SaleBinding s, CancellationToken ct = default)
	// {
	// 	// return base.Post(entity, ct);
	// }
}