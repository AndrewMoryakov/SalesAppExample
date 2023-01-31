using System;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class BuyerController : UniversalController<Entity<Guid>, Guid>
{
	public BuyerController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}