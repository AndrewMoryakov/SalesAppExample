using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Services;

namespace SaleAppExample.Controllers;

public class BuyerController : UniversalController<Buyer, Guid>
{
	private IUserService _us;
	public BuyerController(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}
	
	[ApiExplorerSettings(IgnoreApi = true)]
	public virtual async Task<ActionResult<Buyer>> Post(Buyer entity, CancellationToken ct = default)
	{
		return await base.Post(entity, ct);
	}
}