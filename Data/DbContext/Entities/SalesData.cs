using System;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class SalesData : Entity<Guid>
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public Product Product { get; set; }
	}
}