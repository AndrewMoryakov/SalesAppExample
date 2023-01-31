using System;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class ProviderProductController : UniversalController<ProvidedProduct, Guid>
{
	public ProviderProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}