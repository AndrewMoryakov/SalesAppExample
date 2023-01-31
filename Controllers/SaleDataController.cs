using System;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class SaleDataController : UniversalController<Entity<Guid>, Guid>
{
	public SaleDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}