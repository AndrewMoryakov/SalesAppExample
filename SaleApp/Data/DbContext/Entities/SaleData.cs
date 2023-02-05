using System;
using System.Runtime.Serialization;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class SaleData : BaseEntity<Guid>
	{
		public Guid ProductId { get; set; }
		[IgnoreDataMember]
		public virtual Product Product { get; set; }
		[IgnoreDataMember]
		public Guid SaleId { get; set; }
		[IgnoreDataMember]
		public Sale Sale { get; set; }
		public int ProductQuantity { get; set; }
		[IgnoreDataMember]
		public decimal ProductIdAmount { get; set; }
	}
}