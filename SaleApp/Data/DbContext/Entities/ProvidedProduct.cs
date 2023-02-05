using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class ProvidedProduct : BaseEntity<Guid>
	{
		public Guid ProductId { get; set; }
		[IgnoreDataMember]
		public Product Product { get; set; }
		public Guid SalePointId { get; set; }
		[IgnoreDataMember]
		public SalePoint SalePoint { get; set; }
		public int ProductQuantity { get; set; }
	}
}