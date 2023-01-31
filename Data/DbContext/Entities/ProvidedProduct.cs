using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class ProvidedProduct : Entity<Guid>
	{
		public Guid ProductId { get; set; }
		public Product Product { get; set; }
		public Guid SalePointId { get; set; }
		public SalePoint SalePoint { get; set; }
		public int ProductQuantity { get; set; }
	}
}