using System;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class SalePointController : UniversalController<Entity<Guid>, Guid>
{
	public SalePointController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}