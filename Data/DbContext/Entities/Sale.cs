using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Sale : Entity<Guid>
	{
		public int BuyerId { get; set; }
		public Buyer Buyer { get; set; }
		public int SalesPointId { get; set; }
		public SalesPoint SalesPoint { get; set; }
		public DateTime SaleDate { get; set; }
		public ICollection<SalesData> SalesData { get; set; }
	}
}