using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UniversalController<TEntity, TKey> : ControllerBase where TEntity : Entity<TKey> where TKey:struct
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity, TKey> _repository;

        public UniversalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<TEntity, TKey>();
        }

        [HttpGet]
        public ActionResult<IQueryable<TEntity>> Get()
        {
            var entities =  _repository.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(TKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Post(TEntity entity, CancellationToken ct = default)
        {
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(ct);

            return CreatedAtAction("GetById", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(TKey id, TEntity entity, CancellationToken ct = default)
        {
            if (!id.Equals(entity.Id))
            {
                return BadRequest();
            }

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(ct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(TKey id, CancellationToken ct = default)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(ct);

            return entity;
        }
    }

}