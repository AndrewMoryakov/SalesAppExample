using System;
using System.Runtime.Serialization;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class SaleData : Entity<Guid>
	{
		public Guid ProductId { get; set; }
		[IgnoreDataMember]
		public Product Product { get; set; }
		public int ProductQuantity { get; set; }
		[IgnoreDataMember]
		public decimal ProductIdAmount { get; set; }
	}
}