using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Sale : BaseEntity<Guid>
	{
		
		public Guid BuyerId { get; set; }
		[IgnoreDataMember]
		public Buyer Buyer { get; set; }
		public Guid SalePointId { get; set; }
		[IgnoreDataMember]
		public SalePoint SalePoint { get; set; }
		public ICollection<SaleData> SalesData { get; set; }
		[IgnoreDataMember]
		public decimal TotalAmount { get; set; }
	}
}