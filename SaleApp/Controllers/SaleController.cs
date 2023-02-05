using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaleAppExample.Data;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
	private readonly ISaleStore _saleStore;
	private readonly IRepository<Sale, Guid> _repository;
	private readonly ILogger<SaleController> _logger;
	public SaleController(ISaleStore saleStore, ILogger<SaleController> logger)
	{
		_saleStore = saleStore;
		_logger = logger;
	}

	[HttpPost]
	public async Task<ActionResult<Sale>> Post(Sale entity, CancellationToken ct = default)
	{
		var addedSale = _saleStore.AddAsync(entity, ct);
		return CreatedAtAction("GetById", new {id = addedSale.Id}, addedSale);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Sale>> GetById(Guid id)
	{
		var entity = await _repository.GetByIdAsync(id);
		if (entity == null)
		{
			return NotFound();
		}
		return entity;
	}
}