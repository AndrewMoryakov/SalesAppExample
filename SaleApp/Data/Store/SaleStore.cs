using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Data.UnitOfWork.Repositories;
using SaleAppExample.Exceptions;
using SaleAppExample.Services;

namespace SaleAppExample.Data;

public class SaleStore : ISaleStore
{
	private IRepository<ProvidedProduct, Guid> _saleProvidedRep;
	private IRepository<Sale, Guid> _saleRep;
	private IUnitOfWork _uow;
	private IUserService _us;
	public SaleStore( IRepository<Sale, Guid> saleRep, IUnitOfWork uow, IRepository<ProvidedProduct, Guid> saleProvider,
		IUserService us)
	{
		_saleRep = saleRep;
		_uow = uow;
		_saleProvidedRep = saleProvider;
		_us = us;
	}

	public async Task<Sale> AddAsync(Sale sale, CancellationToken ct)
	{
		async Task ControlProductQuantity(SaleData saleData)
		{
			await ControlExistenceOfEntity<Product, Guid>(saleData.ProductId);
			if ((await _uow.Repository<ProvidedProduct, Guid>().GetAll()
				    .FirstOrDefaultAsync(pp =>
					    pp.ProductId == saleData.ProductId && pp.SalePointId == sale.SalePointId)).ProductQuantity <
			    saleData.ProductQuantity)
				throw new ArgumentException($"Product with {saleData.ProductId} is out of stock");

			if (saleData.ProductQuantity <= 0)
				throw new ArgumentException("Product Quantity is ziro");
		}

		async Task ControlExistenceOfEntity<TEntity, TKey>(Guid entityId) where TEntity : Entity<Guid>
		{
			if (entityId == default || (await _uow.Repository<TEntity, Guid>().ExistsAsync(entityId))==false)
				throw new NotFoundEntityException($"{nameof(entityId)} {sale.SalePointId} not found");
		}

		await ControlExistenceOfEntity<SalePoint, Guid>(sale.SalePointId);
		var buyerId = _us.GetCurrentUserId();//Get auth user
		await ControlExistenceOfEntity<Buyer, Guid>(buyerId);

		var newSale = new Sale
		{
			BuyerId = buyerId,// default value(000000000) if not auth 
			SalePointId = sale.SalePointId
		};
		_saleRep.Insert(newSale);

		var currentSalesData = new List<SaleData>();
		foreach (var saleData in sale.SalesData)
		{
			await ControlProductQuantity(saleData);
			var product = await _uow.Repository<Product, Guid>().GetByIdAsync(saleData.ProductId);
			var checkedSaleData = new SaleData
			{
				
				ProductId = saleData.ProductId,
				ProductQuantity = saleData.ProductQuantity,
				SaleId = newSale.Id,
				ProductIdAmount =  product.Price * saleData.ProductQuantity
			};
			currentSalesData.Add(checkedSaleData);

			var salePointProviderProduct = _saleProvidedRep.GetAll()
				.FirstOrDefault(sd => sd.ProductId == saleData.ProductId && sd.SalePointId == sale.SalePointId);

			salePointProviderProduct.ProductQuantity -= saleData.ProductQuantity;
			_saleProvidedRep.Update(salePointProviderProduct);
		}

		newSale.TotalAmount = currentSalesData.Sum(el => el.ProductIdAmount);

		await _uow.CommitAsync(ct);

		return sale;
	}
}