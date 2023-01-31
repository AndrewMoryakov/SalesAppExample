using System;

namespace SaleAppExample.Data.DbContext;

public struct SaleDataBinding
{
	public Guid ProductId { get; set; }
	public int ProductQuantity { get; set; }
}