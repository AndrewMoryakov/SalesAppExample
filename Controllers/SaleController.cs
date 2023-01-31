using System;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class SaleController : UniversalController<Entity<Guid>, Guid>
{
	public SaleController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}