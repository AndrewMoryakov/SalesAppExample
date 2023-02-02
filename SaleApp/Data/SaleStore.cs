using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Data;

public class SaleStore : ISaleStore
{
	private IRepository<SalePoint, Guid> _salePointRep;
	private IRepository<Sale, Guid> _saleRep;
	private IRepository<SaleData, Guid> _saleDataRep;
	private IUnitOfWork _unitOfWork;
	public SaleStore(CustomBaseDataContext context,
		IRepository<SalePoint, Guid> salePRep, IRepository<Sale, Guid> saleRep,
		IRepository<SaleData, Guid> saleDateRep, IUnitOfWork uow)
	{
		_salePointRep = salePRep;
		_saleRep = saleRep;
		_saleDataRep = saleDateRep;
		_unitOfWork = uow;
	}

	public async Task<Sale> AddAsync(Sale sale, CancellationToken ct)
	{
		var currentSalesData = new List<SaleData>();
		foreach (var saleDate in sale.SalesData)
		{
			var checkedSaleData = new SaleData
			{
				ProductId = saleDate.ProductId, //ToDo проверка существования продукта
				ProductQuantity = saleDate.ProductQuantity //ToDo Проверки доступности
			};
			currentSalesData.Add(checkedSaleData);
		}
		
		_saleRep.Insert(new Sale
		{
			BuyerId = sale.BuyerId, //Проверка того, что такой пользователь есть
			SalesData = currentSalesData
		});

		await _unitOfWork.CommitAsync(ct);
		return sale;
	}
}