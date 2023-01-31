using System;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Controllers;

public class ProductController : UniversalController<Product, Guid>
{
	public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
}