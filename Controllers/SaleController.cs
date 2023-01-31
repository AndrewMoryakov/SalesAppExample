using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class SaleController : UniversalController<Entity<Guid>, Guid>
{
	public SaleController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public override Task<ActionResult<Entity<Guid>>> Post(Entity<Guid> entity, CancellationToken ct = default)
	{
		return base.Post(entity, ct);
	}
}