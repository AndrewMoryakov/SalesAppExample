using System;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class BuyerController : UniversalController<Buyer, Guid>
{
	public BuyerController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}