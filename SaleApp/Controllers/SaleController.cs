using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
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
	
	private readonly IUnitOfWork _unitOfWork;
	private readonly IRepository<Sale, Guid> _repository;

	public SaleController(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
		_repository = _unitOfWork.Repository<Sale, Guid>();
	}
	//
	// [HttpPost]
	// public async Task<ActionResult<Entity<Guid>>> Post(SaleBinding s, CancellationToken ct = default)
	// {
	// 	var sale = s.Adapt<Sale>();
	// 	return Ok(await this.Post(sale, ct));
	// }
	
	[HttpPost]
	public async Task<ActionResult<Sale>> Post(Sale entity, CancellationToken ct = default)
	{
		_repository.Insert(entity);
		await _unitOfWork.CommitAsync(ct);

		return CreatedAtAction("GetById", new { id = entity.Id }, entity);
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