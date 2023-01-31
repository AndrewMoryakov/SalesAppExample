using System;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class SaleData : Entity<Guid>
	{
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
		public int ProductQuantity { get; set; }
		public decimal ProductIdAmount { get; set; }
	}
}