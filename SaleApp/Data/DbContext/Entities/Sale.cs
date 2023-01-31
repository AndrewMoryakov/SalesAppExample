using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Sale : Entity<Guid>
	{
		public Guid BuyerId { get; set; }
		public Buyer Buyer { get; set; }
		public Guid SalePointId { get; set; }
		public SalePoint SalePoint { get; set; }
		public ICollection<SaleData> SalesData { get; set; }
		public decimal TotalAmount { get; set; }
	}
}