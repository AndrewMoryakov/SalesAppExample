using System;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class SaleDataController : UniversalController<SaleData, Guid>
{
	public SaleDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}