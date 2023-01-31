using System;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data;

public class SaleBinding
{
	public Guid BuyerId { get; set; }
	public Guid SalesPointId { get; set; }
	public SaleDataBinding[] SalesData { get; set; }
}