using System;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class ProviderProductController : UniversalController<Entity<Guid>, Guid>
{
	public ProviderProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}