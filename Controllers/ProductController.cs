using System;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Controllers;

public class ProductController : UniversalController<Entity<Guid>, Guid>
{
	public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}